namespace Hackathon{
	using Godot;
	using System;

	public partial class Boat : Node
	{
		public int speed = 100;
		public float durability = 0.5f;
		public int upgrade_level = 1; // out of 100
		
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
		
		public void Upgrade(Player p)
		{
			if (p.HasTool())
			{
				upgrade_level ++;
				p.UseTool();
			}
		}
	}	

}
