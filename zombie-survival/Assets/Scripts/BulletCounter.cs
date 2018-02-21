using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCounter : MonoBehaviour {
	public TMP_Text bulletText;
	// Use this for initialization
	void Start () {

		bulletText = GetComponent<TMP_Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		bulletText.text = "X " + PlayerShooting.bulletCount;
		
	}
}
