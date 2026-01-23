using System;
using Godot;
// Tarvitaan taulukon käyttöön.
using Godot.Collections;

public partial class VehicleRunner : Node
{
	// Direction of the movement. -1 = left, 1 = right.
	[Export] private int _direction = 1;

	// Godot alustaa exportatun muuttujan meidän puolesta.
	[Export] private Array<Vehicle> _vehicles = null;

	public override void _Process(double delta)
	{
		foreach (Vehicle vehicle in _vehicles)
		{
			vehicle.Move(_direction, (float)delta);
		}
	}
}
