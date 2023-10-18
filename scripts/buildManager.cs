using Godot;
using System;
using System.Collections.Generic;

public partial class buildManager : Node
{
    // tableau contenant l'address des scene a instantier pour l'editeur de niveau
   
    public int a = 0;
    [Export]
    public GridContainer buildInventory;
    [Export]
    public PackedScene colorRect;
    [Export]
    public Camera2D camera2D;
    public static Camera2D camera;
    public static Vector2 cameraSize;
    [Export]
    public Node area;
    public static Node areaToSpawnBlock;

    public static String resourcesToInstanciate = "";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        areaToSpawnBlock = area;
        camera = camera2D;
       cameraSize = camera.GetViewportRect().Size;
        for (int i = 0; i < gameManager.nbItemInBuilder; i++) 
        {

            Node instance = colorRect.Instantiate();
            buildInventory.AddChild(instance);
           // GD.Print(gameManager.scenesArray[i,1]);
           
           TextureRect getTextureRect = instance.GetNode<TextureRect>("ItemIcon");
            GD.Print(gameManager.scenesArray[i, 1]);
            Texture2D texture = ImageTexture.CreateFromImage(Image.LoadFromFile(gameManager.scenesArray[i, 1]));
            getTextureRect.Texture = texture;
            instance.Name = gameManager.scenesArray[i, 0];
            // Texture2D newTexture = GD.Load<Texture2D>(gameManager.scenesArray[i, 1]);
            // getTextureRect.Texture =  newTexture;






        }
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
           /* if (resourcesToInstanciate != "")
            {
                PackedScene ground;

                GD.Print("left click try to instantiate a new node ");
                ground = (PackedScene)ResourceLoader.Load(resourcesToInstanciate);
                StaticBody2D newGround = (StaticBody2D)ground.Instantiate();
                spawnNode(newGround);
                GD.Print(mousePos);
                GD.Print(GetViewport().GetMousePosition());
                newGround.Position = mousePos;
            }*/
        }

       


    }
    
   public static void setResourcesToInstanciate(String newResourcesToInstanciate)
    {
        GD.Print(gameManager.scenesDictionary[newResourcesToInstanciate][1]);
        resourcesToInstanciate = gameManager.scenesDictionary[newResourcesToInstanciate][1] ;
    }

   

    public static void instanciateBlock(Vector2 mousePos)
    {
        if (resourcesToInstanciate != "")
        {
            PackedScene ground;
            Vector2 newMousePos = camera.GlobalTransform.Origin + (mousePos - cameraSize  / 2.0f) / camera.Zoom;
            GD.Print("left click try to instantiate a new node ");
            ground = (PackedScene)ResourceLoader.Load(resourcesToInstanciate);
            StaticBody2D newGround = (StaticBody2D)ground.Instantiate();
            
            areaToSpawnBlock.AddChild(newGround);
            GD.Print(newMousePos);
            GD.Print(newMousePos);
            newGround.Position = newMousePos;
          
        }
    }
}
