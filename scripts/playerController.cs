using Godot;
using System;

public partial class playerController : CharacterBody2D
{
	[Export]
	public  float Speed = 300.0f;
    [Export]
    public float sprintSpeed = 600.0f;
    [Export]
    public float stealthSpeed = 150f;

	[Export]
	public int stamina = 1000;
	[Export]
	public int staminaMax = 1000;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;

		

		

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			if (Input.IsActionPressed("sprint") && stamina > 0)
			{
				velocity = direction * sprintSpeed;
				GD.Print(" stamina : " + stamina + " / " + staminaMax);
			}
			else if (Input.IsActionPressed("walk"))
			{
				velocity = direction * stealthSpeed;
			}
            else if (Input.IsActionPressed("hide"))
            {
                velocity = Vector2.Zero;
				GD.Print("i am hide ");
            }
            else
			{
				velocity = direction * Speed;
			}
		}
        else

        {
			velocity =Vector2.Zero;
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
