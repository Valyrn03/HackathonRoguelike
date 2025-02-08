namespace Hackathon{
	using Godot;
	using System;
	public partial class Tool : Area2D
	{
		public override void _Ready()
		{
			Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		}

		private void OnBodyEntered(Node body)
		{
			if (body is Player player)
			{
				player.PickUpTool(this);
			}
		}
	}
}
