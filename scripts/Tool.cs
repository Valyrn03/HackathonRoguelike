using Godot;

public partial class Tool : Node
{
	private Sprite2D sprite; // Reference to the Sprite2D child

	public string ToolType { get; set; }

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));

	   Node childNode = GetNode("YourChildNodeName");
		if (childNode is Sprite2D)
		{
			sprite = (Sprite2D)childNode;
		}
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player player)
		{
			player.PickUpTool(this);
		}
	}

	public Texture2D ToolImage()
	{
		return sprite.Texture;
		
	}
}
