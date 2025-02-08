using Godot;
using System;

public partial class loadPlayer : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
{
	var playerScene = GD.Load<PackedScene>("res://dock.tscn");
	var playerInstance = (Player)playerScene.Instantiate();
	
	AddChild(playerInstance);
	playerInstance.GlobalPosition = new Vector2(100, 200); // Set spawn position
}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
