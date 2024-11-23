using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{
    public partial class Greatsword : Weapon
    {
        public override void _Ready()
        {
            SetType(WeaponType.Greatsword);
        }

        public override void Hit()
        {
            AnimationPlayer.Play("hit");
            hitbox.Attack = new()
            {
                AttackDamage = Damage,
                KnockbackForce = knockback,
                AttackPosition = GlobalPosition
            };
        }
    }
}

