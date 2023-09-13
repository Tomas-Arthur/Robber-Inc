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
<<<<<<< HEAD
	public double staminaMax = 1000;

	[Export]
	public double staminaLostPerSecond;
	[Export]
	public double timeToRecupStamina;
	[Export]
	public double timeToRecupStaminaMax;

    public double oneSecond = 1f;
	public double twoSecond = 2;

	[Export]
	public bool hiding = false;
=======
	public int staminaMax = 1000;
>>>>>>> parent of 3b07ce7 (add stamina system + affichage dans le terminal)

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
			//on sprint que si la stamina n'est pas null
			if (Input.IsActionPressed("sprint") && stamina > 0)
			{
<<<<<<< HEAD
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
				// on affiche l'etat de la stamina dans le teminal
=======
				velocity = direction * sprintSpeed;
>>>>>>> parent of 3b07ce7 (add stamina system + affichage dans le terminal)
				GD.Print(" stamina : " + stamina + " / " + staminaMax);
			}
			// si on presse la touche de marche on change la vitesse de deplacement par celle de la marche
			else if (Input.IsActionPressed("walk"))
			{
				velocity = direction * stealthSpeed;
				twoSecond -= delta;
			}
			// si caché ne se deplace pas 
            else if (hiding)
            {
                velocity = Vector2.Zero;
                twoSecond -= delta;
                //GD.Print("i am hide ");
            }
            else
			{
<<<<<<< HEAD
				velocity = direction * Speed ;
                twoSecond -= delta;
            }
=======
				velocity = direction * Speed;
			}
>>>>>>> parent of 3b07ce7 (add stamina system + affichage dans le terminal)
		}
        else

        {
			velocity =Vector2.Zero;
<<<<<<< HEAD
            twoSecond -= delta;
        }

		// gestion recuperation de la stamina une fois arrivé a zero
		// a ameliorer pour la restauré dés que le joueur ne cours plus 
		if(stamina<=0)
		{
			if(timeToRecupStamina - delta < 0)
			{
				stamina = staminaMax;
				timeToRecupStamina = timeToRecupStaminaMax;
				GD.Print("stamina recovered");
            }
			else
			{
				timeToRecupStamina -= delta;

            }
		}
		if(twoSecond <= 0 && stamina > 0)
		{
			if(oneSecond - delta < 0)
			{
				stamina += 10;
				oneSecond = 1;
                GD.Print(" stamina : " + stamina + " / " + staminaMax);
            }
			else
			{
				oneSecond -= delta;
			}
		}
=======
		}
		
>>>>>>> parent of 3b07ce7 (add stamina system + affichage dans le terminal)
		Velocity = velocity;
		MoveAndSlide();

		
	}

    public override void _Input(InputEvent @event)
    {
		//gere l'input de "hide" et change l'etat du bool 
        if (@event.IsActionPressed("hide"))
        {
            hiding = !hiding;
        }
    }


}
