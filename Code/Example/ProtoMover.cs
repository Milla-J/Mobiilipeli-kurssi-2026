using System;
using Godot;

public partial class ProtoMover : Node2D
{
	[Export]
	private Vector2 _direction = Vector2.Zero;

	/// <summary>
	/// The speed in pixels / second.
	/// </summary>
	[Export]
	private float _speed = 1;

	[Export]
	private bool _pingPong = false;

	[Export]
	private Vector2 _position1 = new Vector2(100, 100);

	[Export]
	private Vector2 _position2 = new Vector2(500, 100);

	[Export] private Node2D _point1 = null;
	[Export] private Node2D _point2 = null;
	[Export] private float _offset = 1;

	private Node2D _target = null;

	public override void _Ready()
	{
		// Normalisoi vektorin, muuntaa sen pituuden yhdeksi samalla säilyttäen suunnan.
		_direction = _direction.Normalized();

		if (_pingPong)
		{
			_target = _point2;
			GlobalPosition = _point1.GlobalPosition;
		}
	}

	public override void _Process(double delta)
	{
		if (_pingPong)
		{
			MovePingPong((float)delta);
		}
		else
		{
			MoveDirection((float)delta);
		}
	}

	private void MovePingPong(float delta)
	{
		// Laske liikkeen suunta
		Vector2 direction = (_target.GlobalPosition - GlobalPosition).Normalized();
		Vector2 movement = direction * _speed * delta;
		Translate(movement);
		if (GlobalPosition.DistanceTo(_target.GlobalPosition) <= _offset)
		{
			// Onko etäisyys kohdepisteeseen riittävän pieni?
			// Jos on, vaihda kohde.
			GlobalPosition = _target.GlobalPosition;
			ToggleTarget();
		}
	}

	private void MoveDirection(float delta)
	{
		Vector2 movement = _direction * _speed * delta;
		Translate(movement);

		GD.Print($"Speed: {movement.Length() / delta} pixels / second.");
	}

	private void ToggleTarget()
	{
		if (_target == _point2)
		{
			_target = _point1;
		}
		else
		{
			_target = _point2;
		}
	}
}
