
	

using Godot;
using System.Collections.Generic;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 400.0f;  // Move speed
	[Export] public float Gravity = 500.0f;  // Gravity force
	[Export] public float JumpForce = 300.0f;  // Jump strength
	public List<Tool> tools = new List<Tool>(); // Player tools
	private AnimatedSprite2D playerAnimation;

	public override void _Ready()
	{	
			// get hte tools
		tools = CharacterData.tools;

		playerAnimation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		playerAnimation.Play("idle");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		// Apply gravity if not on the floor
		if (!IsOnFloor())
		{
			Velocity += new Vector2(0, Gravity * (float)delta);
		}

		// Handle movement
		if (Input.IsActionPressed("move_left"))
		{
			direction.X -= 1;
			playerAnimation.Play("walk");
			playerAnimation.FlipH = true; // Flip sprite when moving left
		}
		else if (Input.IsActionPressed("move_right"))
		{
			direction.X += 1;
			playerAnimation.Play("walk");
			playerAnimation.FlipH = false; // Unflip sprite when moving right
		}
		else
		{
			// Play idle animation when not moving
			playerAnimation.Play("idle");
		}

		direction = direction.Normalized();
		Velocity = new Vector2(direction.X * Speed, Velocity.Y);

		// Jumping
		if (Input.IsActionJustPressed("move_up") && IsOnFloor())
		{
			Velocity = new Vector2(Velocity.X, -JumpForce);
		}

		MoveAndSlide();
	}


public void PickUpTool(Tool tool)
{
	GD.Print("Picked up: " + tool.Name);
	Tool newT = (Tool)tool.Duplicate(); // Duplicate the tool

	tools.Add(newT);
	GD.Print("Player has " + tools.Count + " tools");
	GD.Print(newT);
	tool.QueueFree(); // Removes the tool from the scene

	// change character sheet
	CharacterData.tools = tools;
}

	private void _on_body_entered(Node body)
	{
		if (body is Tool tool)
		{
			PickUpTool(tool);
		}
	}

	public bool HasTool()
	{
		return tools.Count > 0;
	}

	public Tool UseTool()
	{
		if (HasTool())
		{
			Tool t = tools[0] ;
			tools.RemoveAt(0); // Remove the first tool
			return t;
		}
		return null;
	}
}
