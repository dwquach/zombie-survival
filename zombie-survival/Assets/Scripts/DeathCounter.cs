using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathCounter : MonoBehaviour {

	public static int deathRemaining = 50;
	public Text deathText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deathText.text = "Kills Remaining: " + deathRemaining;
	}


}
