using Godot;
using IngotDefenders.scenes.core.components;

namespace IngotDefenders.scripts.core
{
    public abstract partial class Projectile : Node2D
    {
        [ExportCategory("Projectile Stats")]
        [Export] public HitboxComponent hitbox;
        [Export] public float Duration { get; set; } = 3;
        [Export] public float Speed { get; set; }
        [Export] public float Damage { get; set; } = 10;
        [Export] public float Knockback { get; set; } = 0;
        public float Direction { get; set; }

        public virtual void Process(double delta) { }
        public virtual void OnReady() { }
        public virtual void OnKill() { }

        public override void _Ready()
        {
            OnReady();
            hitbox.Attack = new()
            {
                AttackDamage = Damage,
                KnockbackForce = Knockback,
                AttackPosition = GlobalPosition
            };
        }
        public override void _Process(double delta)
        {
            Duration -= (float)delta;
            GlobalPosition += new Vector2(Speed * Direction * (float)delta, 0);
            Process(delta);
            KillOnTimeout();
        }


        private void KillOnTimeout()
        {
            if (Duration <= 0)
            {
                Kill();
            }
        }
        private void Kill()
        {
            OnKill();
            QueueFree();
        }
    }
}