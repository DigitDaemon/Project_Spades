using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 6f;
	Vector3 movement; // A 3d vector for x,y, and z components
	Rigidbody playerRigidBody;
	int floorMask;
	float camRayLength = 100;

	// You should know when this is called
	void Awake(){
		// This gets the mask for the layer named floor (found in the top right of an object)
		floorMask = LayerMask.GetMask ("Floor");
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	// Called every physics step
	void FixedUpdate(){
		// "Horizonal" is the name of the input set by unity
		// This input can be found and changed at edit->projectsettings->input
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h, v);
		Turning ();
	}

	void Move( float h, float v )
	{
		movement.Set (h, 0f, v);
		//normalize it to make sure the magnatude is 1
		//speed is our speed (hardcoded)
		//Move is called every fixed update, which is pretty dam fast (which is called every 50th of a second in this case)
		//So we multiply it by Time.deltaTime, which is the time between each call
		movement = movement.normalized * speed * Time.deltaTime;

		//We move the player object using transform, which is the current object data, and grab its position
		//We then apply our movement to it to get the new position and set it using the method
		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		//I'm gonna try to explain this. The player must face the mouse. Because the mouse is locked relative the camera and screen, than we can cast a ray from the camera
		//onto the floor, and we can get that position where that ray lands. The player must look at that point.
		//Set up the ray and the resulting ray hit
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		//Perform the ray cast
		//Requires: the ray to cast, the output data reference, the length of the ray, and what it's expected to hit
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			//We cannot use a vector to rotate stuff, gotta change it into this thing
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidBody.MoveRotation (newRotation);
		}
	}
}
