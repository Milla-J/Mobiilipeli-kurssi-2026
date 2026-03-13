using System;
using Godot;

public partial class LevelController : Node2D
{
	// TODO: Täällä tulee olemaan tasoon liittyvää logiikkaa.
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Register the level to the Game Manager. This will become the active level.
		GameManager.Instance.RegisterLevel(this);
	}
}
