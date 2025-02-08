using Godot;
using System;

public partial class player : Sprite2D
{
    private int _speed = 400;
    private float _angularSpeed = Mathf.Pi;
    private int direction = 1;

    public override void _Process(double delta){
        if(Input.IsActionPressed("ui_left")){
            direction = -1;
            System.Console.WriteLine("Left");
        }
        if(Input.IsActionPressed("ui_right")){
            direction = 1;
            System.Console.WriteLine("Right");
        }
        Rotation += _angularSpeed * (float)delta * direction;
    }

    public override void _Ready(){
        System.Console.WriteLine("Hello World");
    }
}