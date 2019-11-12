using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Reference to the player
	public Transform player;
	// Speed of the enemy
	public float speed = 1;
	// Reference to this rigid body
	Rigidbody enemyRigidBody;
    public float attackRange;
    public float buffer;
    public float attackSpeed;
    private Vector3 startPosition;
    public bool isDashing=false;
    public bool targetReached = false;
    private Vector3 targetPosition;
	// Use this for initialization
	void Awake () {
		// Initiate the reference to the current rigid body
		enemyRigidBody = GetComponent<Rigidbody> ();
		player = GameObject.Find("Player").transform;
	}

	// Update is called once per game update
	void FixedUpdate () {
        
        if (Vector3.Distance(player.position, enemyRigidBody.position) < attackRange && !isDashing)
        {
            isDashing = true;
            startPosition = enemyRigidBody.position;
            targetPosition = player.position;
        }
            

        if (!isDashing)
        {
            // The resultant vector of the diff between enemy and player
            Vector3 movement = player.position - transform.position;
            // Cancel out y movement value, no need to go up or down
            movement.y = 0;
            // Create a new rotation based on movement so enemy looks at player
            Quaternion newRotation = Quaternion.LookRotation(movement);
            // Required offset
            newRotation *= Quaternion.Euler(0, -90, 0);
            // Apply the rotation
            enemyRigidBody.MoveRotation(newRotation);
            // Normalize and even out the movement
            movement = movement.normalized * speed * Time.deltaTime;
            // Apply the movement
            enemyRigidBody.MovePosition(transform.position + movement);
        }
        else if (!targetReached)
        {
            if (Vector3.Distance(targetPosition, enemyRigidBody.position) > 0 + buffer)
            {
                // The resultant vector of the diff between enemy and player
            Vector3 movement = targetPosition - transform.position;
            // Cancel out y movement value, no need to go up or down
            movement.y = 0;
            // Create a new rotation based on movement so enemy looks at player
            Quaternion newRotation = Quaternion.LookRotation(movement);
            // Required offset
            newRotation *= Quaternion.Euler(0, -90, 0);
            // Apply the rotation
            enemyRigidBody.MoveRotation(newRotation);
            // Normalize and even out the movement
            movement = movement.normalized * attackSpeed * Time.deltaTime;
            // Apply the movement
            enemyRigidBody.MovePosition(transform.position + movement);
            }
            else
            {
                targetReached = true;
            }
        }
        else if(targetReached)
        {
            if (Vector3.Distance(startPosition, enemyRigidBody.position) > 0 + buffer)
            {
                // The resultant vector of the diff between enemy and player
                Vector3 movement = startPosition - transform.position;
                // Cancel out y movement value, no need to go up or down
                movement.y = 0;
                // Create a new rotation based on movement so enemy looks at player
                Quaternion newRotation = Quaternion.LookRotation(movement);
                // Required offset
                newRotation *= Quaternion.Euler(0, -90, 0);
                // Apply the rotation
                enemyRigidBody.MoveRotation(newRotation);
                // Normalize and even out the movement
                movement = movement.normalized * attackSpeed * Time.deltaTime;
                // Apply the movement
                enemyRigidBody.MovePosition(transform.position + movement);
            }
            else
            {
                isDashing = false;
                targetReached = false;
            }
        }
	}

}
