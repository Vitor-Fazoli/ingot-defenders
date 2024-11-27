using Godot;

public partial class SpawnEnemies : Path2D
{
	[Export] public PackedScene enemy;

	public void EnemySpawn()
	{
		PathFollow2D path_follow = new();
		AddChild(path_follow);
		EnemyBase i = enemy.Instantiate<EnemyBase>();
		path_follow.AddChild(i);
		GetNode<Timer>("Timer").Start();
	}
}
