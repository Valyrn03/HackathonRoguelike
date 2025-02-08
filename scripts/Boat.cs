using Godot;
using System;
using System.Collections.Generic;

public partial class Boat : Node
{
	public int speed = 100;
	public float durability = 0.5f;
	public int upgrade_level = 0;
	public int maxUpgradeLevel = 1; // arbitrary number

	// The child of the boat change the image based on reparedness
	private Sprite2D image;
	private Button upgrade_button;

	private Player player;

	private int numRod = 0;

	
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
				case "Metal Panel": 
					image.Texture = GD.Load<Texture2D>("res://sprites/boat/boat_hole.png");
					break;

				case "SailR":
					// add a sail!
					Sprite2D sail = GetNode<Sprite2D>("SailR");
					GD.Print("Adding sail");
					GD.Print(sail);
					sail.Visible = true;
					break;

				case "SailL":
					// add a sail!
					Sprite2D sailL = GetNode<Sprite2D>("SailL");
					GD.Print("Adding sail");
					GD.Print(sailL);
					sailL.Visible = true;
					break;

				case "Motor":
					// add a motor!
					Sprite2D motor = GetNode<Sprite2D>("Motor");
					GD.Print("Adding motor");
					GD.Print(motor);
					motor.Visible = true;
					break;

				case "Propeller":
					// add a propeller!
					AnimatedSprite2D propeller = GetNode<AnimatedSprite2D>("Propeller");
					propeller.Visible = true;
					break;

				case "Rod":
					numRod ++;
					if (numRod > 1){
						// add a mast! 
						Sprite2D mast = GetNode<Sprite2D>("Mast");
						GD.Print("Adding mast");
						GD.Print(mast);
						mast.Visible = true;
					}
					break;
				
				default:
					GD.Print("No tool to upgrade boat");
					break;
			}

			if (upgrade_level >= maxUpgradeLevel)
			{
				FinishBoat();
				
			}
		}
		else {
			GD.Print("No tools to upgrade boat");
		}
	}

	public void FinishBoat()
	{
		GD.Print("Boat is finished!");
		// remove old sail away button for new one
		Button sailAway = GetNode<Button>("Sail Away");
		// get greyed out version
		Sprite2D sailAwayGrey = sailAway.GetNode<Sprite2D>("Sail Away Grey");
		// invisible 
		sailAwayGrey.Visible = false;
		// get green version
		Sprite2D sailAwayGreen = sailAway.GetNode<Sprite2D>("Sail Away Green");
		GD.Print(sailAwayGreen);
		sailAwayGreen.Visible = true;
	} 

	public void SailAway()
	{
		GD.Print("Sailing away!");
		// change scene
		GetTree().ChangeSceneToFile("res://scenes/sail.tscn");
	}
}	
