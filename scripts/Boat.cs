using Godot;
using System;
using System.Collections.Generic;

public partial class Boat : Node
{
	public int speed = 100;
	public float durability = 0.5f;
	public int upgrade_level = 0; // out of 100

	// The child of the boat change the image based on reparedness
	private Sprite2D image;
	private Button upgrade_button;

	private Player player;



	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		image = GetNode<Sprite2D>("BoatImage");
		upgrade_button = GetNode<Button>("Upgrade");

		player = GetNode<Player>("/root/Node2D/Player");
		GD.Print(player);
		
		upgrade_button.Pressed += OnButtonPressed;

	}

	private void OnButtonPressed()
	{
		GD.Print("Button pressed");
		Upgrade();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void Upgrade()
	{
		if (player.HasTool())
		{
			GD.Print("Upgrading boat");	

			upgrade_level ++;
			Tool tool = player.UseTool();
		
			// update the sprite based on the upgrade level
			switch (tool.Name)
			{
				case "metal panel": 
					image.Texture = GD.Load<Texture2D>("res://sprites/boat/boat_hole.png");
					break;
				
				case "phone":
					// add a mast! 
					Sprite2D mast = GetNode<Sprite2D>("Mast");
					GD.Print("Adding mast");
					GD.Print(mast);
					mast.Visible = true;
					break;

				
				default:
					image.Texture = GD.Load<Texture2D>("res://sprites/boat/boat_broken.png");
					break;
			}
		}
		else {
			GD.Print("No tools to upgrade boat");
		}
	}
}	
