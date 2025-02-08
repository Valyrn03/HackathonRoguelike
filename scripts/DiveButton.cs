using Godot;

public partial class DiveButton : Area2D
{
	[Export] public string SceneToLoad = "res://scenes/map.tscn"; // Set this in the Inspector

	public override void _Ready()
	{
		// Connect the button's pressed signal to the function
		this.BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player){     
			CharacterData.inWater = true;   
		// Change to the new scene
		GetTree().ChangeSceneToFile(SceneToLoad);  
		}
		
	}
}
