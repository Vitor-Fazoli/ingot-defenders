using Godot;
using IngotDefenders.scripts.core;

namespace IngotDefenders.scenes.core.components
{
	public partial class HealthComponent : Node2D
	{
		[Export] private float HealthPointsMax { get; set; } = 10;
		private float _healthPoints;

		public override void _Ready()
		{
			_healthPoints = HealthPointsMax;
		}

		public void Damage(Attack attack)
		{
			_healthPoints -= attack.AttackDamage;

			if (_healthPoints <= 0)
			{
				GetParent().QueueFree();
			}
		}
	}
}