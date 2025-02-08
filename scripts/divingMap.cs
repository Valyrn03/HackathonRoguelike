using Godot;
using System;
using System.Collections.Generic;

public partial class divingMap : TileMapLayer
{
	public List<tileCell> tiles;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Random random = new Random();
		defineCells();
		for(int i = 0; i < 5; i++){
			for(int j = 0; j < 5; j++){
				SetCell(new Vector2I(i, j), 0, new Vector2I(random.Next(0, 4), random.Next(0, 4)), random.Next(0, 4));
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void defineCells(){
		tiles = new List<tileCell>
        {
            new(0, 0, new List<int>(), new List<int> { 0, 3 }, new List<int>(), new List<int>()),
            new(1, 0, new List<int> { 3 }, new List<int> { 0 }, new List<int> { 1 }, new List<int> { 2 }),
            new(2, 0, new List<int>(), new List<int> { 1, 3 }, new List<int> { 0 }, new List<int> { 2 }),
            new(3, 0, new List<int> { 0 }, new List<int> { 2 }, new List<int> { 1 }, new List<int> { 3 }),
            new(0, 1, new List<int> { 2 }, new List<int>(), new List<int> { 2 }, new List<int>()),
            new(1, 1, new List<int>(), new List<int> { 2 }, new List<int> { 1 }, new List<int>()),
            new(2, 1, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 0 }, new List<int> { 1 }),
            new(3, 1, new List<int>(), new List<int>(), new List<int>(), new List<int> { 0, 2 }),
            new(0, 2, new List<int> { 1 }, new List<int> { 1 }, new List<int>(), new List<int> { 1 }),
            new(1, 2, new List<int> { 2 }, new List<int> { 1 }, new List<int>(), new List<int> { 0, 3 }),
            new(2, 2, new List<int> { 1 }, new List<int>(), new List<int> { 0, 2 }, new List<int>()),
            new(3, 2, new List<int> { 3 }, new List<int> { 2 }, new List<int>(), new List<int>()),
            new(0, 3, new List<int> { 0 }, new List<int>(), new List<int>(), new List<int>()),
            new(1, 3, new List<int> { 1 }, new List<int>(), new List<int>(), new List<int>()),
            new(2, 3, new List<int> { 2 }, new List<int>(), new List<int>(), new List<int>()),
            new(3, 3, new List<int> { 3 }, new List<int>(), new List<int>(), new List<int>())
        };
	}
}
