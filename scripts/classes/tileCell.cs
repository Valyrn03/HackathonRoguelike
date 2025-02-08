using System.Collections.Generic;
using System.Numerics;
using Godot;

public class tileCell{
    private Vector2I id;
    private List<List<int>> connections;
    private List<Vector3I> variations;
    private int variationSelected;

    public tileCell(int vert, int hori, List<int> north, List<int> east, List<int> south, List<int> west){
        id.X = hori;
        id.Y = vert;

        connections = new List<List<int>>
        {
            north,
            east,
            south,
            west
        };
        variationSelected = -1;
    }

    public Vector2I getCoordinates(){
        return id;
    }

    public List<Vector3I> GetOptions(int openWall, Vector2I source, TileMapLayer tileMap){
        int direction = getDirection(source);
        List<Vector3I> cellList = new List<Vector3I>();
        for(int i = 0; i < 4; i++){
            if(connections[(direction + i) % 4].Contains(openWall)){
                cellList.Add(variations[i]);
            }
        }
        return cellList;
    }

    public bool buildVariations(){
        for(int i = 0; i < 4; i++){
            variations.Add(new Vector3I(id.X, id.Y, i));
        }
        return true;
    }

    private int getDirection(Vector2I other){
        if(other.X == id.X - 1){
            return 3;
        }else if(other.Y == id.X + 1){
            return 2;
        }else if(other.X == id.X + 1){
            return 1;
        }else{
            return 0;
        }
    }

    public Vector3I getTile(){
        if(variationSelected == -1){
            return new Vector3I(id.X, id.Y, 0);
        }else{
            return variations[variationSelected];
        }
    }

    public List<int> getDirectionalConnection(int direction){
        return connections[direction];
    }
}