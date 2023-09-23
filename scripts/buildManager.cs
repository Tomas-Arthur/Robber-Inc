using Godot;
using System;
using System.Collections.Generic;

public partial class buildManager : Node
{
    // tableau contenant l'address des scene a instantier pour l'editeur de niveau
    [Export]
    public String[] listScene ;
    public int a = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
	}


    public override void _Input(InputEvent @event)
    {
        Vector2 mousePos = Vector2.Zero;
        if (@event is InputEventMouseButton eventMouseButton)
        {
             
            mousePos = eventMouseButton.Position;
           

            
            
        }

        if (@event.IsActionPressed("left_click"))
        {
            PackedScene ground;
           
            GD.Print("left click try to instantiate a new node ");
            ground = (PackedScene)ResourceLoader.Load("res://scenes/wall.tscn");
            StaticBody2D newGround = (StaticBody2D)ground.Instantiate();
            AddChild(newGround);
            GD.Print(mousePos);
            GD.Print(GetViewport().GetMousePosition());
            newGround.Position = mousePos;
        }
    }



}