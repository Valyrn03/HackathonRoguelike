using Godot;
using System;
using System.Collections.Generic;
using System.Numerics;

public partial class divingMap : TileMapLayer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Random random = new Random();

        GD.Print(System.IO.Directory.GetCurrentDirectory());
        // Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(random.Next(0, 5));
        Dictionary<Vector2I, Vector3I> tiles = mapLevels.GetMap(0);
		GD.Print("Found Map, Total Tiles: " + tiles.Count);

		GD.Print("Adding Tiles: ");
        foreach(KeyValuePair<Vector2I, Vector3I> tile in tiles){
			GD.Print("\tAdding Tile At" + tile.Key.X + ", " + tile.Key.Y);
            SetCell(tile.Key, 0, new Vector2I(tile.Value.X, tile.Value.Y), 0);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }
}
