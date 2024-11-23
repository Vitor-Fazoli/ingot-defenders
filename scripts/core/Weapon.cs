using Godot;
using IngotDefenders.scenes.core.components;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scenes.core.player
{
	public partial class Weapon : Node2D
	{
		public WeaponType Type { get; set; }

		[ExportCategory("Stats")]
		[Export] public float Damage;
		[Export] public float knockback;

		[ExportCategory("GameAttributes")]
		[Export] public Vector2 HoldPosition;
		[Export] public float HoldAngle;
		[Export] public bool HoldBehindPlayer;
		[Export] public bool FollowMousePos;
		[Export] public AnimationPlayer AnimationPlayer;
		[Export] public HitboxComponent hitbox;
		[Export] public Sprite2D Sprite;

		public void Hit()
		{
			AnimationPlayer.Play("hit");
			hitbox.Attack = new()
			{
				AttackDamage = Damage,
				KnockbackForce = knockback,
				AttackPosition = GlobalPosition
			};
		}

		public override void _Process(double delta)
		{
			if (FollowMousePos is true)
			{
				Rotation = Position.AngleTo(GetGlobalMousePosition());
			}
		}
	}
}