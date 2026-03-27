using System;
using Godot;

public partial class KillZone : Area2D
{
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
		if (body is PlayerCharacter player)
		{
			player.Health.CurrentHealth = 0;
		}
	}
}
