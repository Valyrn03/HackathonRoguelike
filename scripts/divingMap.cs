using Godot;
using System;
using System.Collections.Generic;
using System.Numerics;

public partial class divingMap : TileMapLayer
{
<<<<<<< HEAD
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Random random = new Random();

        GD.Print(System.IO.Directory.GetCurrentDirectory());
        // Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(random.Next(0, 5));
        Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(0);

        foreach(KeyValuePair<Vector2I, Vector3I> tile in tiles){
            SetCell(tile.Key, 0, new Vector2I(tile.Value.X, tile.Value.Y), tile.Value.Z);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }
}
=======
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Random random = new Random();
		
		GD.Print(System.IO.Directory.GetCurrentDirectory());
		// Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(random.Next(0, 5));
		Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(0);

		foreach(KeyValuePair<Vector2I, Vector3I> tile in tiles){
			SetCell(tile.Key, 0, new Vector2I(tile.Value.X, tile.Value.Y), tile.Value.Z);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


}
>>>>>>> 9072a895e8de64e5f17ec279878e7afa3b3070f5
