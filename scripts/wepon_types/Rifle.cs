using System;
using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{
	public partial class Rifle : Weapon
	{
		public override void _Ready()
		{
			Type = WeaponType.Rifle;
		}
	}
}

