using System;
using Godot;

public partial class Fibonacci : Node
{
	private int _previous = 0;
	private int _current = 1;
	private int _frameCounter = 0;

	private bool _continue = true;

	public override void _Process(double delta)
	{
		if (_previous > 1000)
		{
			if (!_continue)
			{
				return;
			}

			_continue = false;
		}

		_frameCounter++;

		// GD.Print("Frame: " + _frameCounter + ": " + _previous);
		GD.Print($"Frame: {_frameCounter}: {_previous}");

		int next = _previous + _current;
		_previous = _current;
		_current = next;
	}
}
