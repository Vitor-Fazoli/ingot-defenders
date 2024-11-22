using Godot;
using System;

public partial class VelocityComponent : Node2D
{
	[Export] public CharacterBody2D Entity { get; set; }

	[ExportCategory("Stats")]
	[Export] public float Speed;

	public override void _Process(double delta)
	{
		if (Entity is null) { return; }

		Vector2 pos = Entity.Position;
		pos.X -= Speed * (float)delta;
		Entity.Position = pos;
	}
}
