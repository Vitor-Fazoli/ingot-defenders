using Godot;
using IngotDefenders.scenes.core.components;
using System;
namespace IngotDefenders.scenes.core.projectiles
{
	public partial class MusketBall : Node2D
	{
		[Export]
		public HitboxComponent hitbox;
		private GpuParticles2D trail;

		public float Damage { get; set; } = 10;
		public float Knockback { get; set; } = 0;

		public override void _Ready()
		{
			trail = GetNode<GpuParticles2D>("GPUParticles2D");
			trail.Emitting = true;
			hitbox.Attack = new()
			{
				AttackDamage = Damage,
				KnockbackForce = Knockback,
				AttackPosition = GlobalPosition
			};

			//hitbox.Connect(HitboxComponent.SignalName.AreaEntered, Callable.From<MusketBall>(Kill));
		}
		public void Kill(MusketBall ball)
		{
			ball.QueueFree();
		}

		public override void _Process(double delta)
		{
			GlobalPosition += new Vector2(100 * (float)delta, 0);
		}
	}

}
