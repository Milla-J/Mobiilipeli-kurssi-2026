using System;
using Godot;

public partial class Vehicle : Sprite2D
{
	[Export] private Color _color = Colors.White;
	[Export] private float _maxSpeed = 10.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Toteuta täällä kaikki se toiminnallisuus, joka suoritetaan jokaisella framella
		// - Esim. käyttäjän syötteen luku
		// - Hahmon liikutus (ilman fysiikoita)
	}

	/// <summary>
	/// Moves the vehicle to a direction defined by attribute "direction" with speed _maxSpeed:
	/// </summary>
	/// <param name="direction">The direction of the movement. -1 = left, 1 = right.</param>
	public void Move(int direction)
	{
		if (direction < -1 || direction > 1)
		{
			// Direction is not valid. Nothing to do.
			return;
		}

		// TODO: Palaa tähän, kun olemme testanneet toteutuksen.
		Vector2 movement = new Vector2(direction, 0);
		Translate(movement);
	}
}
