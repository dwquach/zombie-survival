using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour {
	public static int wavesDone;
	public static int deathRemaining;
	public TMP_Text deathText;
	public static int zombiesMade;
	public static int zombiesMadeLimit;
	public GameObject upgrade;
	public GameObject winnerCanvas;
	public GameObject inGameMenu;
	public bool done;
	public bool resetDone;

    GameObject loseScreen;
    GameObject player;
    PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		upgrade = GameObject.FindGameObjectWithTag("Finish");
		winnerCanvas = GameObject.FindGameObjectWithTag("Finish2");
        loseScreen = GameObject.FindGameObjectWithTag("Finish3");
        player = GameObject.FindGameObjectWithTag("Player");
		inGameMenu = GameObject.FindGameObjectWithTag ("Menu");
        playerHealth = player.GetComponent<PlayerHealth>();
        upgrade.SetActive (false);
		winnerCanvas.SetActive (false);
        loseScreen.SetActive(false);
		inGameMenu.SetActive (true);
		deathText = GetComponent<TMP_Text> ();
		zombiesMadeLimit = 10;
		deathRemaining = 10;
		zombiesMade = 0;
		wavesDone = 0;
		done = false;
		resetDone = false;
	}

	// Update is called once per frame
	void Update () {
		
        if (playerHealth.currentHealth <= 0)
        {
            loseScreen.SetActive(true);
			Time.timeScale = 0;
			inGameMenu.SetActive (false);
        }

        deathText.text = "" + deathRemaining;
		if (deathRemaining == 0) {
			if (!resetDone) {
				wavesDone++;
				resetDone = true;
			}
			Time.timeScale = 0;
			if (wavesDone == 5) {
				done = true;
				winnerCanvas.SetActive (true);
				inGameMenu.SetActive (false);
			} 
			if(!done) {
				inGameMenu.SetActive (false);
				upgrade.SetActive(true);
			}


		}
	}

	public void resetWave(){
		zombiesMadeLimit += 5;
		deathRemaining =zombiesMadeLimit;
		zombiesMade = 0;
		Time.timeScale = 1;
		resetDone = false;
		EnemySpawner.spawnTime *= .95f;
		inGameMenu.SetActive (true);
	}


}
