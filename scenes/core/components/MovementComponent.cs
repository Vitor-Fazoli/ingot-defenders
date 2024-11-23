using System.ComponentModel.DataAnnotations;
using Godot;
using GodotPlugins.Game;
using IngotDefenders.scripts.core;

public partial class MovementComponent : Node2D
{
	[Export] public CharacterBody2D Entity { get; set; }

	[ExportCategory("Stats")]
	[Export] public float Speed;
	[Export] public float KnockbackResistence = 0;

	[Export]
	public Callable SetMovement;


	public void Knockback(Attack attack)
	{
		if (Entity is null) { return; }


		float direction = attack.AttackPosition.DirectionTo(GlobalPosition).X;

		attack.KnockbackForce -= KnockbackResistence;

		float knockbackForce = direction > 0 ? attack.KnockbackForce : -attack.KnockbackForce;

		GD.Print(knockbackForce);

		Vector2 knockbackVec2 = new(knockbackForce, 0);

		Entity.GlobalPosition += knockbackVec2;

		knockbackVec2.Lerp(Vector2.Zero, 5);
	}

	public override void _PhysicsProcess(double delta)
	{
		SetMovement.Call();
	}
}
