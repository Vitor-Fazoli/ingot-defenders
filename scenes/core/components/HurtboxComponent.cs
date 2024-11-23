using Godot;

namespace IngotDefenders.scenes.core.components
{
    public partial class HurtboxComponent : Area2D
    {
        [Export]
        public HealthComponent healthComponent;
        [Export]
        public MovementComponent movementComponent;

        public override void _Ready()
        {
            Connect(SignalName.AreaEntered, Callable.From<HitboxComponent>(OnHitboxEntered));
        }

        public void OnHitboxEntered(HitboxComponent hitbox)
        {
            if (hitbox is null)
            {
                return;
            }

            healthComponent?.Damage(hitbox.Attack);
            movementComponent?.Knockback(hitbox.Attack);
        }
    }
}