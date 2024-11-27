using Godot;
using IngotDefenders.scripts.core;

public partial class HolyFire : Projectile
{
	public void OnBodyEntered(Node2D node)
	{
		QueueFree();
	}
}
