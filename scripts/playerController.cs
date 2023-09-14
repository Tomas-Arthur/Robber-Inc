using Godot;
using System;

public partial class playerController : CharacterBody2D
{
	[Export]
	public float Speed = 300f;
	[Export]
	public float sprintSpeed = 600f;
	[Export]
	public float stealthSpeed = 150f;

	[Export]
	public double stamina = 100;
	[Export]
	public	double staminaMax = 100;

	[Export]
	public double staminaLostPerSecond ;
	[Export]
	public double timeToRecupStamina ;
	[Export]
	public double timeToRecupStaminaMax ;

	public double oneSecond = 1;
	public double twoSecond = 2;

	[Export]
	public bool hiding = false;


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
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		GD.Print("test");
	}
}
