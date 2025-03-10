using System.Collections.Generic;
using System.Numerics;
using Godot;

public class mapLevels{
    public static Dictionary<Vector2I, Vector3I> GetMap(int i){
        switch(i){
            case 0: return GetMapOne();
            case 1: return GetMapTwo();
            case 2: return GetMapThree();
            case 3: return GetMapFour();
            case 4: return GetMapFive();
        }
        return null;
    }

    //map.Add(new Vector2I(), new Vector3I());
    public static Dictionary<Vector2I, Vector3I> GetMapOne(){
        Dictionary<Vector2I, Vector3I> map = new Dictionary<Vector2I, Vector3I>();

        map.Add(new Vector2I(0, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(1, 0), new Vector3I(2, 2, 0));
        map.Add(new Vector2I(2, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(3, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(4, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(0, 1), new Vector3I(0, 2, 0));
        map.Add(new Vector2I(1, 1), new Vector3I(0, 0, 0));
        map.Add(new Vector2I(2, 1), new Vector3I(2, 1, 0));
        map.Add(new Vector2I(3, 1), new Vector3I(3, 0, 0));
        map.Add(new Vector2I(4, 1), new Vector3I(1, 1, 0));
        map.Add(new Vector2I(1, 2), new Vector3I(5, 1, 0));
        map.Add(new Vector2I(2, 2), new Vector3I(3, 1, 0));
        map.Add(new Vector2I(3, 2), new Vector3I(4, 0, 0));
        map.Add(new Vector2I(4, 2), new Vector3I(3, 1, 0));
        map.Add(new Vector2I(1, 3), new Vector3I(4, 4, 0));
        map.Add(new Vector2I(2, 3), new Vector3I(1, 1, 0));
        map.Add(new Vector2I(3, 3), new Vector3I(1, 0, 0));
        map.Add(new Vector2I(4, 3), new Vector3I(3, 0, 0));
        map.Add(new Vector2I(2, 4), new Vector3I(4, 1, 0));
        map.Add(new Vector2I(3, 4), new Vector3I(2, 1, 0));
        map.Add(new Vector2I(4, 4), new Vector3I(0, 1, 0));

        return map;
    }

    public static Dictionary<Vector2I, Vector3I> GetMapTwo(){
        Dictionary<Vector2I, Vector3I> map = new Dictionary<Vector2I, Vector3I>();

        map.Add(new Vector2I(0, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(1, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(2, 0), new Vector3I(2, 2, 0));
        map.Add(new Vector2I(3, 0), new Vector3I(3, 2, 0));
        map.Add(new Vector2I(4, 0), new Vector3I(3, 2, 0));

        map.Add(new Vector2I(2, 1), new Vector3I(2, 0, 0));
        map.Add(new Vector2I(-1, 2), new Vector3I(0, 2, 0));
        map.Add(new Vector2I(0, 2), new Vector3I(1, 1, 0));
        map.Add(new Vector2I(2, 2), new Vector3I(4, 0, 0));
        map.Add(new Vector2I(3, 2), new Vector3I(1, 1, 0));
        map.Add(new Vector2I(4, 2), new Vector3I(0, 2, 0));
        map.Add(new Vector2I(5, 2), new Vector3I(1, 1, 0));
        map.Add(new Vector2I(6, 2), new Vector3I(3, 1, 0));
        map.Add(new Vector2I(0, 3), new Vector3I(4, 0, 0));
        map.Add(new Vector2I(1, 3), new Vector3I(2, 1, 0));
        map.Add(new Vector2I(2, 3), new Vector3I(2, 0, 0));
        map.Add(new Vector2I(3, 3), new Vector3I(5, 0, 0));
        map.Add(new Vector2I(5, 3), new Vector3I(4, 0, 0));
        map.Add(new Vector2I(0, 4), new Vector3I(5, 0, 0));
        map.Add(new Vector2I(2, 4), new Vector3I(4, 1, 0));
        map.Add(new Vector2I(3, 4), new Vector3I(2, 1, 0));
        map.Add(new Vector2I(4, 4), new Vector3I(2, 1, 0));
        map.Add(new Vector2I(5, 4), new Vector3I(0, 1, 0));

        return map;
    }

    public static Dictionary<Vector2I, Vector3I> GetMapThree(){
        return null;
    }

    public static Dictionary<Vector2I, Vector3I> GetMapFour(){
        return null;
    }

    public static Dictionary<Vector2I, Vector3I> GetMapFive(){
        return null;
    }
}
