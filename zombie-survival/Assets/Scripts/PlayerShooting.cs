﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
    public int maxBulletCount = 20;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public GameObject menu;
    public GameObject menuButton;

    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	public static int bulletCount;
    private bool reloading = false;

    void Awake()
    {
		
		bulletCount = maxBulletCount;
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");

        // Set up the references.
        gunLine = gun.GetComponent<LineRenderer>();
        gunAudio = gun.GetComponent<AudioSource>();
        gunLight = gun.GetComponent<Light>();
    }

    private IEnumerator reload()
    {
        reloading = true;
        gunAudio.clip = reloadSound;
        gunAudio.Play();
        yield return new WaitForSeconds(3);
        bulletCount = maxBulletCount;
        reloading = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            menuButton.SetActive(false);
            menu.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            menu.SetActive(false);
            menuButton.SetActive(true);
            Time.timeScale = 1;
        }

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
		if (Input.GetKeyDown ("r") && bulletCount < 30 && !reloading)
        {
            StartCoroutine(reload());
		}
        // If the Fire1 button is being press and it's time to fire...
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && !reloading)
        {
            // ... shoot the gun.
            Shoot();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

	public void increaseDamage(){
		damagePerShot += 10;
	}

    public void incraseAmmo()
    {
        maxBulletCount += 10;
    }


    void Shoot()
	{

		if (bulletCount > 0) {
			bulletCount--;
			// Reset the timer.
			timer = 0f;

            // Play the gun shot audioclip.
            gunAudio.clip = shootSound;
			gunAudio.Play ();

			// Enable the light.
			gunLight.enabled = true;

			// Enable the line renderer and set it's first position to be the end of the gun.
			gunLine.enabled = true;
			Vector3 gunPosition = new Vector3 (transform.position.x, transform.position.y + 1.75f, transform.position.z);
			gunLine.SetPosition (0, gunPosition);

			// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
			shootRay.origin = gunPosition;
			shootRay.direction = transform.forward;

			// Perform the raycast against gameobjects on the shootable layer and if it hits something...
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
				// Try and find an EnemyHealth script on the gameobject hit.
				EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();

				// If the EnemyHealth component exist...
				if (enemyHealth != null) {
					// ... the enemy should take damage.
					enemyHealth.TakeDamage (damagePerShot);
				}

				// Set the second position of the line renderer to the point the raycast hit.
				gunLine.SetPosition (1, shootHit.point);
			}
        // If the raycast didn't hit anything on the shootable layer...
        	else {
				// ... set the second position of the line renderer to the fullest extent of the gun's range.
				gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			}
		} else
        {
            StartCoroutine(reload());
        }
	}
}
