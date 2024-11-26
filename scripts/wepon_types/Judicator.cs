using Godot;
using IngotDefenders.scenes.core.player;
using IngotDefenders.scripts.core;
using IngotDefenders.scripts.enums;

namespace IngotDefenders.scripts.weapon_types
{
    public abstract partial class Judicator : Weapon
    {
        [ExportCategory("Judicator Stats")]
        [Export]
        public PackedScene Bullet;
        [Export]
        public RayCast2D SpeedRaycast;
        private bool _fireTurn = false;
        public override void _Ready()
        {
            SetType(WeaponType.Judicator);
        }

        public override void Hit()
        {
            if (!AnimationPlayer.IsPlaying())
            {
                if (_fireTurn)
                {
                    _fireTurn = false;
                    AnimationPlayer.Play("hit_2");
                }
                else
                {
                    _fireTurn = true;
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

        public void InstantiateBullet()
        {
            Projectile proj = Bullet.Instantiate<Projectile>();

            proj.GlobalPosition = SpeedRaycast.GlobalPosition;
            proj.Damage = Damage;
            proj.Knockback = knockback;

            Vector2 mousePos = GetGlobalMousePosition();

            proj.Direction = mousePos.X - GlobalPosition.X > 0 ? 1 : -1;
            proj.Speed = SpeedRaycast.TargetPosition.X;

            GetTree().CurrentScene.AddChild(proj);
        }
    }

}

