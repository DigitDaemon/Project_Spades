using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    public int playerHealth;
    public int damageTaken;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<EnemyMovement>())
        {
            playerHealth -= damageTaken;
        }
    }
    public int getLife()
    {
        return playerHealth;
    }
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
