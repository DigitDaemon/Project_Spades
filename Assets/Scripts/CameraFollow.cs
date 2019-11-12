using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	//The target for the camera to follow
	//This is assigned in unity by dragging the player gameobject from hierarchy into the "target" slot
	public Transform target;
	//How fast the camera should move
	public float smoothing = 5f;

	Vector3 offset;

	void Start(){
		//Grab the current distance the camera is from the target.
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
		//The position the camera needs to make it to using the given offset and target's position
		Vector3 targetCamPos = target.position + offset;
		//Move the camera to that position. Lerp will "nudge" the camera towards that direction
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
