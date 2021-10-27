using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierAIController : MonoBehaviour
{

	public GameObject Enemy;
	Animator anim;

	[SerializeField] float rotationSpeed = 2.0f;
	[SerializeField] float speed = 2.0f;
	[SerializeField] float visDist = 20.0f;
	[SerializeField] float visAngle = 30.0f;
	[SerializeField] float shootDist = 5.0f;

	[SerializeField] AudioClip shootSound;
	[SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
	[SerializeField] ParticleSystem shootEffects;

	//[SerializeField] float damage = 5f;


	string state = "assault_combat_idle";

	// Use this for initialization
	void Start()
	{
		anim = this.GetComponent<Animator>();
		Enemy = GameObject.FindGameObjectWithTag("enemy");
		shootEffects.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 direction = Enemy.transform.position - this.transform.position;

		float angle = Vector3.Angle(direction, this.transform.forward);


		if (direction.magnitude < visDist && angle < visAngle)
		{

			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction),
										Time.deltaTime * rotationSpeed);

			if (direction.magnitude > shootDist)
			{
				if (state != "assault_combat_run")
				{
					state = "assault_combat_run";
					anim.SetTrigger("isRunning");
				}
			}
			else
			{
				if (state != "assualt_combat_shoot")
				{
					state = "assualt_combat_shoot";
					anim.SetTrigger("isShooting");
					Fire();
					shootEffects.Play();
					AttackHitEvent();

				}
			}

		}
		else
		{
			if (state != "assault_combat_idle")
			{
				state = "assault_combat_idle";
				anim.SetTrigger("isIdle");
				
			}
		}

		if (state == "assault_combat_run")
			this.transform.Translate(0, 0, Time.deltaTime * speed);

	}

	private void Fire()
	{
		AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

	}

	public void AttackHitEvent()
	{
		Enemy.GetComponent<enemyAIController>().TakeDamage();
		
	}
}