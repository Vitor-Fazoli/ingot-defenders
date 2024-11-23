using System;
using Godot;
using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{
	public partial class Rifle : Weapon
	{
		[ExportCategory("Rifle Stats")]
		[Export]
		public PackedScene Bullet;
		[Export]
		public Marker2D FirePosition;
		public override void _Ready()
		{
			SetType(WeaponType.Rifle);
		}

		public override void Hit()
		{
			AnimationPlayer.Play("hit");
			Node2D inst = Bullet.Instantiate<Node2D>();
			inst.Position = FirePosition.Position;
			GetParent().GetParent().GetParent().AddChild(inst);
		}
	}
}

