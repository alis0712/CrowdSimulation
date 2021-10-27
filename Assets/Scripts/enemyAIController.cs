using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIController : MonoBehaviour 
{

	public GameObject player;
	Animator anim;

	[SerializeField] float rotationSpeed = 2.0f;
	[SerializeField] float speed = 2.0f;
	[SerializeField] float visDist = 20.0f;
	[SerializeField] float visAngle = 30.0f;
	[SerializeField] float shootDist = 5.0f;

	[SerializeField] AudioClip shootSound;
	AudioSource robot;
	[SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

	[SerializeField] GameObject projectile;
	float projectileSpeed = 10f;


	[SerializeField] float hitPoints = 100f;
	float damage;


	string state = "IDLE";

	// Use this for initialization
	void Start () 
	{
		robot = GetComponent<AudioSource>();
		anim = this.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		
	}

	// Update is called once per frame
	void Update()
	{

		Vector3 direction = player.transform.position - this.transform.position;


		float angle = Vector3.Angle(direction, this.transform.forward);

		if (direction.magnitude < visDist && angle < visAngle && hitPoints > 0)
		{

			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction),
										Time.deltaTime * rotationSpeed);

			if (direction.magnitude > shootDist )
			{
				if (state != "RUNNING")
				{
					state = "RUNNING";
					anim.SetTrigger("isRunning");
				}
			}
			else
			{
				if (state != "SHOOTING")
				{
					state = "SHOOTING";
					anim.SetTrigger("isShooting");
					Fire();

				}
				
			}

		}
		else
		{
			if (state != "IDLE" )
			{
				state = "IDLE";
				anim.SetTrigger("isIdle");
				TakeDamage();

			}

			
		}

		if (state == "RUNNING")
		{
			this.transform.Translate(0, 0, Time.deltaTime * speed);
	
		}


	}

	private void Fire()
	{
		GameObject laser = Instantiate(
			projectile,
			transform.position,
			Quaternion.Euler(-90f, 0, 0)
			) as GameObject;

		laser.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, projectileSpeed);
		AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);	
	}

	public void TakeDamage()
    {
		hitPoints = -damage;
		{ 
			robot.Stop();
			
		}
	}
}
