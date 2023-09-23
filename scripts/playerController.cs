using Godot;
using System;

public partial class playerController : CharacterBody2D
{
	[Export]
	public float Speed ;
	[Export]
	public float sprintSpeed;
	[Export]
	public float stealthSpeed ;

	[Export]
	public double stamina ;
	[Export]
	public	double staminaMax;

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
	[Export]
	public double staminaRecoveredBySecond;

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
			// on sprint si le stamina n'est pas null
			if(Input.IsActionPressed("sprint") && stamina >0)
			{
				twoSecond = 2;
				velocity = direction * sprintSpeed ;
				if(oneSecond - delta < 0)
				{
					stamina -= staminaLostPerSecond;
					oneSecond = 1;
				}
				else
				{
					oneSecond -= delta;
				}
				// on affiche l'etat de la stamina dans le terminal
				GD.Print(" stamina : " + stamina + " / " + staminaMax);
			}
			// si on press la touche de marche on change la vitesse de deplacement par celle de la marche 
			else if(Input.IsActionPressed("walk"))
			{
				velocity = direction * stealthSpeed;
				twoSecond -= delta;
			}
			//si cach� on ne se deplace pas
			else if(hiding)
			{
				velocity = Vector2.Zero;
				twoSecond -= delta;
			}
			else
			{
				velocity = direction * Speed;
				twoSecond -= delta;
			}
		}
		else
		{
			velocity = Vector2.Zero;
			twoSecond -= delta;
		}

		Velocity = velocity;
		MoveAndSlide();
		//GD.Print("test");

		// gestion de la recuperation de la stamina une fois arriv� a zero
		if(stamina <= 0)
		{
			if(timeToRecupStamina - delta <0)
			{
				stamina = staminaMax;
				timeToRecupStamina = timeToRecupStaminaMax;
				//GD.Print("stamina recovered");
			}
			else
			{
				timeToRecupStamina -= delta;
			}
		}
		if (stamina > 0 && stamina < staminaMax && twoSecond < 0) 
		{
			if(oneSecond - delta < 0) 
			{
				stamina += staminaRecoveredBySecond;
				oneSecond = 1;
				GD.Print(" stamina : " + stamina + " / " + staminaMax);
			}
			else
			{
				oneSecond -= delta;
			}
		}
	}

	// gere les key pressed 
	// ici si on appuis sur ctrl pour se cacher
	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("hide"))
		{
			hiding = !hiding;
		}
	}




}
