using Godot;
using IngotDefenders.scenes.core.components;

namespace IngotDefenders.scripts.core
{
    public abstract partial class Projectile : Node2D
    {
        [ExportCategory("Projectile Stats")]
        [Export] public HitboxComponent hitbox;
        [Export] public float TimeLeft { get; set; }
        [Export] public float Speed { get; set; }
        [Export] public float Damage { get; set; } = 10;
        [Export] public float Knockback { get; set; } = 0;
        public float Direction { get; set; }

        public override void _Ready()
        {
            hitbox.Attack = new()
            {
                AttackDamage = Damage,
                KnockbackForce = Knockback,
                AttackPosition = GlobalPosition
            };
            hitbox.Connect("HitEventHandler", new Callable(this, nameof(Kill)));
        }
        public override void _Process(double delta)
        {
            GlobalPosition += new Vector2(Speed * Direction * (float)delta, 0);
            Process(delta);
        }

        public virtual void Process(double delta) { }

        public virtual void OnKill() { }

        private void Kill()
        {
            OnKill();
            QueueFree();
        }
    }
}