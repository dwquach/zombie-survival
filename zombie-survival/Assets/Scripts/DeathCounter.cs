using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathCounter : MonoBehaviour {

	public static int deathRemaining;
	public TMP_Text deathText;
	public static int zombiesMade;
	public GameObject upgrade;
	// Use this for initialization
	void Start () {
		upgrade = GameObject.FindGameObjectWithTag("Finish");
		upgrade.SetActive (false);
		deathText = GetComponent<TMP_Text> ();

		deathRemaining = 1;
		zombiesMade = 0;
	}
	
	// Update is called once per frame
	void Update () {
		deathText.text = "Zombies Remaining: " + deathRemaining;

		if (deathRemaining == 0) {
			Time.timeScale = 0;
			upgrade.SetActive(true);
		}
	}

	public void resetWave(){
		deathRemaining = 50;
		zombiesMade = 0;
		Time.timeScale = 1;
	}


}
