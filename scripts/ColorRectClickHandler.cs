using Godot;
using System;

public partial class ColorRectClickHandler : ColorRect
{
	[Signal]
	public delegate void onMouseClickEventHandler(int colorRectIndex);

	public int ColorRectIndex { get; set; }

	public override void _Ready()
	{
	   

	}

	private void _on_ColorRect_mouse_button_pressed(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{

			// Le bouton gauche de la souris a été cliqué.
			// Vous pouvez ajouter votre logique de gestion de clic ici.
			GD.Print("Clic gauche de la souris détecté !");
            GD.Print("ColorRect cliqué ! Index : " + this.Name);
			buildManager.setResourcesToInstanciate(this.Name);
        }
	}

   
}



