using Godot;
using System;

public partial class buildAreaSrcipt : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsActionPressed("left_click"))
		{
			buildManager.instanciateBlock(GetViewport().GetMousePosition());
			//GD.Print(this);
        }
	}
}



