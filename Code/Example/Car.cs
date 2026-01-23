using System;
using Godot;

public partial class Car : Vehicle
{
	[Export] private int _doorCount = 2;

	public override string GetVehicleInfo()
	{
		return "This is a car. Door count: " + _doorCount;
	}
}
