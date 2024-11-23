using Godot;
using IngotDefenders.scenes.core.components;
using System;

public partial class MusketBall : Node2D
{
	[Export]
	public HitboxComponent hitbox;

	public float Damage { get; set; } = 10;
	public float Knockback { get; set; } = 0;

	public override void _Ready()
	{
		hitbox.Attack = new()
		{
			AttackDamage = Damage,
			KnockbackForce = Knockback,
			AttackPosition = GlobalPosition
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition += new Vector2(10 * (float)delta, 0);
	}
}
