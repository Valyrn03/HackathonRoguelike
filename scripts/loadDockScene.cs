using Godot;

public partial class loadDockScene : Button
{
	[Export] public string SceneToLoad = "res://scenes/dock.tscn"; // Set this in the Inspector

	public override void _Ready()
	{
		// Connect the button's pressed signal to the function
		this.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile(SceneToLoad);
	}
}
