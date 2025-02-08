
	

using Godot;
using System.Collections.Generic;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 400.0f;  // Move speed
	[Export] public float Gravity = 500.0f;  // Gravity force
	[Export] public float JumpForce = 300.0f;  // Jump strength
	public List<Tool> tools = new List<Tool>(); // Player tools
	private AnimatedSprite2D playerAnimation;

	private bool inWater = false;

	public override void _Ready()
	{	
			// get hte tools
		tools = CharacterData.tools;
		inWater = CharacterData.inWater;

		playerAnimation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		playerAnimation.Play("idle");
	}

	public override void _Process(double delta)
	{
		// put a box for each thing collected 
		for (int i = 0; i < tools.Count; i++)
		{
			Sprite2D box = new Sprite2D();
			box.Texture = GD.Load<Texture2D>("res://images/openBox.png");
			box.Position = new Vector2(50 + i * 50, -20);
			box.Scale = new Vector2(0.05f, 0.05f);
			AddChild(box);
		}
	}
	public override void _PhysicsProcess(double delta)
{
	Vector2 direction = Vector2.Zero;

	// Apply gravity if not on the floor and not swimming
	if (!IsOnFloor() && !inWater)
	{
		Velocity += new Vector2(0, Gravity * (float)delta);
	}

	// Handle horizontal movement (left-right)
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
		playerAnimation.Play("idle");
	}

	// Swimming vertical movement (up-down)
	if (inWater)
	{
		if (Input.IsActionPressed("move_up"))
		{
			direction.Y -= 1;
			playerAnimation.Play("swim");
		}
		else if (Input.IsActionPressed("move_down"))
		{
			direction.Y += 1;
			playerAnimation.Play("swim");
		}
		else
		{
			direction.Y = 0;
			playerAnimation.Play("idle");
		}
	}

	// Normalize direction vector (same behavior for both axes)
	direction = direction.Normalized();

	// Apply velocity based on direction and speed
	Velocity = new Vector2(direction.X * Speed, direction.Y * Speed / 20 + Velocity.Y);

	// Jumping logic (reset Y velocity when jumping)
	if (Input.IsActionJustPressed("move_up") && IsOnFloor())
	{
		Velocity = new Vector2(Velocity.X, -JumpForce); // Apply jump force
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
			CharacterData.tools = tools;
			return t;
		}
		return null;
	}
}
