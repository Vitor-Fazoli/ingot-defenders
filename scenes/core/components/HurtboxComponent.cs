using Godot;

namespace IngotDefenders.scenes.core.components
{
    public partial class HurtboxComponent : Area2D
    {
        [Export]
        public HealthComponent healthComponent;

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

            if (hitbox.IsProjectile)
            {
                hitbox.GetParent().QueueFree();
            }
        }
    }
}