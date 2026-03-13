using System;
using Godot;

public partial class Goal : Area2D
{
	[Export]
	private string _nextLevelPath = "res://";

	public override void _EnterTree()
	{
		BodyEntered += OnBodyEntered;
	}

	public override void _ExitTree()
	{
		BodyEntered -= OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is PlayerCharacter)
		{
			GameManager.Instance.GoToScene(_nextLevelPath);
		}
	}
}
