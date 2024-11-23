using Godot;
using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{
    public abstract partial class Judicator : Weapon
    {
        public override void _Ready()
        {
            SetType(WeaponType.Judicator);
        }

        public override void Hit()
        {
            throw new System.NotImplementedException();
        }
    }

}

