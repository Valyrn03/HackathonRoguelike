using Godot;
using System;
using System.Collections.Generic;



public partial class CharacterData : Node
{
	public static List<Tool> tools = new List<Tool>();

	public static bool inWater = false;
	private List<Sprite2D> boxes = new List<Sprite2D>();


	// You can also add methods to load and save data if needed.
}
