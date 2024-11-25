using Godot;
using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.core;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{

	public abstract partial class Rifle : Weapon
	{
		[ExportCategory("Rifle Stats")]
		[Export]
		public PackedScene Bullet;
		[Export]
		public RayCast2D SpeedRaycast { get; set; }
		public override void _Ready()
		{
			SetType(WeaponType.Rifle);
		}

		public override void Hit()
		{
			AnimationPlayer.Play("hit");
		}

		public void InstantiateBullet()
		{
			Projectile proj = Bullet.Instantiate<Projectile>();

			proj.GlobalPosition = SpeedRaycast.GlobalPosition;

			Vector2 mousePos = GetGlobalMousePosition();

			proj.Direction = mousePos.X - GlobalPosition.X > 0 ? 1 : -1;

			proj.Speed = SpeedRaycast.TargetPosition.X;

			GetTree().CurrentScene.AddChild(proj);
		}
	}
}

