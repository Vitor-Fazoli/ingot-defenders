using System.ComponentModel;
using Godot;
using IngotDefenders.scenes.core.components;
using IngotDefenders.scripts.core;

namespace IngotDefenders.scenes.core.player
{
	public partial class Weapon : Node2D
	{
		[ExportCategory("Stats")]
		[Export] public float Damage;
		[Export] public float knockback;

		[ExportCategory("Improvements")]
		[Export] public float Acceleration;
		[Export] public float Power;
		[Export] public float Bouncing;

		[ExportCategory("GameAttributes")]
		[Export] public new Vector2 Position;
		[Export] public new float Rotation;
		[Export] public bool HoldBehindPosition;
		[Export] public AnimationPlayer AnimationPlayer;
		[Export] public HitboxComponent hitbox;
		[Export] public Sprite2D Sprite;

		public void Hit()
		{
			AnimationPlayer.Play("hit");
			hitbox.Attack = new()
			{
				AttackDamage = Damage,
				KnockbackForce = knockback
			};
		}
	}
}