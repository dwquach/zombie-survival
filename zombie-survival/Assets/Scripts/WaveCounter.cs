using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour {

    private float currentWave = 0;
    private TMP_Text waveText;

	// Use this for initialization
	void Start () {
        waveText = GetComponent<TMP_Text>();
	}
	
	// Update is called once per frame
	void Update () {
        currentWave = DeathCounter.wavesDone + 1;
        waveText.SetText("WAVE " + currentWave + " / 5");
	}
}
