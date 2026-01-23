using System;
using Godot;

public partial class Vehicle : Sprite2D
{
	[Export] private Color _color = Colors.White;
	[Export] private float _maxSpeed = 10.0f;

	// Property on tapa validoida jäsenmuuttujien arvoja. Property näyttää ulospäin muuttujalta, 
	// todellisuudessa taustalla on get- ja set-metodit, joissa voidaan esim. tehdä datan validointia.
	public Color CurrentColour
	{
		get { return _color; }
		protected set
		{
			if (value != _color)
			{
				_color = value;
			}
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Suorita GetVehicleInfo() saadaksesi ajoneuvon tiedot merkkijonona ja tulosta ne konsoliin.
		GD.Print(GetVehicleInfo());

		// Set correct colour for the vehicle.
		Modulate = _color;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Toteuta täällä kaikki se toiminnallisuus, joka suoritetaan jokaisella framella
		// - Esim. käyttäjän syötteen luku
		// - Hahmon liikutus (ilman fysiikoita)
	}

	// Virtual-avainsana tarkoittaa sitä, että metodin toteutus voidaan ylikirjoittaa lapsiluokassa.
	// Ylikirjoittaminen tapahtuu override avainsanan avulla.
	/// <summary>
	/// Returns the vehicle info.
	/// </summary>
	/// <returns>The string letting caller know what kind of vehicle this is.</returns>
	public virtual string GetVehicleInfo()
	{
		return String.Empty;
	}

	/// <summary>
	/// Moves the vehicle to a direction defined by attribute "direction" with speed _maxSpeed:
	/// </summary>
	/// <param name="direction">The direction of the movement. -1 = left, 1 = right.</param>
	/// <param name="deltaTime">The time since the previous frame.</param>
	public void Move(int direction, float deltaTime)
	{
		if (direction < -1 || direction > 1)
		{
			// Direction is not valid. Nothing to do.
			return;
		}

		// Liikevektori saadaan muunettua pikseleiksi sekunnissa kertomalla se sillä ajalla,
		// joka on kulunut edellisestä framesta. Muuten nopeuden olisi pikseliä framen aikana.
		Vector2 movement = new Vector2(direction, 0) * _maxSpeed * deltaTime;
		Translate(movement);
	}
}
