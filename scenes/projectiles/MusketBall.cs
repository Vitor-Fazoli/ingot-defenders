using IngotDefenders.scripts.core;

public partial class MusketBall : Projectile
{
    public void OnBodyEntered(Godot.Node2D node)
    {
        QueueFree();
    }
}
