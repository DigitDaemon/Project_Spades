/***************************************************************
* author: Tony L. & Llyod Z.
* class: CS 470 
*
* assignment: final project
* date last modified: 3/20/2112
*
* purpose: This script will spawn enemies
*
****************************************************************/

using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 2f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public Transform player; 				// Reference to the current player. Used for target of enemy at spawn
    private int escalation = 5;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        // If the enemy has a movement script, find it
		EnemyMovement movement = enemy.GetComponent<EnemyMovement> ();
		// Assign the player reference to the enemy so the enemy knows where the player is
        if (movement)
		{
			movement.player = player;
		}

        if (Random.Range(0, 100) <= escalation)
        {
            if (spawnTime - .1 > 0)
            {
                spawnTime -= .1F;
                escalation += escalation / 2;
            }
        }
    }

}
