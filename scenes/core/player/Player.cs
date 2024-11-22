using Godot;
using IngotDefenders.scenes.core.player;

namespace IngotDefenders.scripts.core.player
{
	public partial class Player : CharacterBody2D
	{
		private AnimatedSprite2D _sprite;

		[Export]
		private Weapon weapon;

		private bool _smithMode = false;

		public override void _Ready()
		{
			_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		}
		public override void _Process(double delta)
		{
			if (Input.IsActionJustPressed("smith_mode"))
			{
				_smithMode = !_smithMode;
			}

			if (_smithMode is true)
			{

			}
			else
			{
				MovementAnimation(Velocity);
			}

			if (Input.IsMouseButtonPressed(MouseButton.Left))
			{
				weapon.Hit();
			}
		}
		private float Speed { get; set; } = 45.0f;

		private const float JumpVelocity = -150.0f;

		public override void _PhysicsProcess(double delta)
		{
			if (_smithMode)
			{
				SmithingAnimation();
			}
			else
			{
				MovementPhysics(Velocity, delta);
			}
		}
		private void MovementPhysics(Vector2 movement, double delta)
		{
			Vector2 velocity = Velocity;

			if (!IsOnFloor())
			{
				velocity += GetGravity() * (float)delta;
			}

			if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			{
				velocity.Y = JumpVelocity;
			}

			Vector2 direction = Input.GetVector("move_left", "move_right", "jump", "ui_down");
			if (direction != Vector2.Zero)
			{
				velocity.X = direction.X * Speed;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}

			Velocity = velocity;
			MoveAndSlide();
		}
		private void SmithingAnimation()
		{
			_sprite.Animation = "smithing";
		}
		private void MovementAnimation(Vector2 movement)
		{
			// Change animation when is in movement
			_sprite.Animation = Velocity != Vector2.Zero ? "walk" : "idle";

			Vector2 offset = Position - GetGlobalMousePosition();

			// Change side of sprite
			_sprite.FlipH = !(offset.X < 0);
			weapon.SetScale(new Vector2(offset.X > 0 ? -1 : 1, 1));
		}
	}
}
