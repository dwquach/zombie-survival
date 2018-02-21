using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public static float spawnTime = 1f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Debug.Log(spawnPoints.Length);
		if (DeathCounter.zombiesMade < DeathCounter.zombiesMadeLimit) {
			DeathCounter.zombiesMade++;
			Debug.Log (DeathCounter.zombiesMade);
			Instantiate (enemy, new Vector3 (Random.Range (-21, 18), 0, Random.Range (-22, 22)), spawnPoints [spawnPointIndex].rotation);
		}
    }
}
