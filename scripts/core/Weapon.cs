using Godot;
using IngotDefenders.scenes.core.components;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scenes.core.player
{
	public abstract partial class Weapon : Node2D
	{
		public WeaponType Type { get; set; }

		[ExportCategory("Stats")]
		[Export] public float Damage;
		[Export] public float knockback;

		[ExportCategory("GameAttributes")]
		[Export] public AnimationPlayer AnimationPlayer;
		[Export] public HitboxComponent hitbox;
		[Export] public Sprite2D Sprite;

		public abstract void Hit();
		public void SetType(WeaponType wType)
		{
			Type = wType;
		}
	}
}