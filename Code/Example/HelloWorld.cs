using System;
using Godot;

public partial class HelloWorld : Node
{
	private int _frameCounter = 0;

	public override void _Ready()
	{
		GD.Print("Hello, World!");
	}

	public override void _Process(double delta)
	{
		// _frameCounter = _frameCounter + 1;
		_frameCounter++;
		GD.Print("Frame: " + _frameCounter);
	}
}
