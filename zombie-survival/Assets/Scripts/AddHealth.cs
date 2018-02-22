using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour {

    public float addAmount = 25;

    private GameObject player;
    private PlayerHealth playerHealth;
    private AudioSource healthSound;
    private Collider trig;
    private MeshRenderer render;

	// Use this for initialization
	void Start () {
        healthSound = GetComponent<AudioSource>();
        trig = GetComponent<BoxCollider>();
        render = GetComponent<MeshRenderer>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player")
        {
            healthSound.Play();

            if (playerHealth.currentHealth < 100 && playerHealth.currentHealth > 100 - addAmount)
            {
                playerHealth.currentHealth = 100;
            } else if (playerHealth.currentHealth < 100)
            {
                playerHealth.currentHealth += addAmount;
            }

            Debug.Log("Player health: " + playerHealth.currentHealth);
            playerHealth.healthSlider.value = playerHealth.currentHealth;
            trig.enabled = false;
            render.enabled = false;
            Destroy(gameObject, 2f);
        }
	}
}
