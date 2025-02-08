using Godot;

public partial class loadDockScene : Button
{
	[Export] public string SceneToLoad = "res://dock.tscn"; // Set this in the Inspector

	public override void _Ready()
	{
		// Connect the button's pressed signal to the function
		this.Pressed += OnButtonPressed;
	}

	private async void OnButtonPressed()
	{
		await ToSignal(GetTree().CreateTimer(1.0f), "timeout"); // Wait 1 second
		GetTree().ChangeSceneToFile(SceneToLoad);
	}
}
