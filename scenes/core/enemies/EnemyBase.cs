using Godot;
using IngotDefenders.scenes.core.components;
using IngotDefenders.scripts.core;

public partial class EnemyBase : CharacterBody2D
{
	[ExportCategory("Enemy Components")]
	[Export] HitboxComponent hitbox;
	[Export] HealthComponent health;
	[Export] HurtboxComponent hurtbox;
	public override void _Ready()
	{
		hitbox.Attack = new Attack
		{
			AttackDamage = 5,
		};
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}
