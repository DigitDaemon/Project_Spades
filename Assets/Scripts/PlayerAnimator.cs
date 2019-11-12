using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	// Reference to the animator
	public Animation anim;
	// Is the player moving?
	private bool moving;

	// Use this for initialization
	void Start () {
		// Set reference to animation component
		anim = GetComponent<Animation> ();
	}

	// Called every game update
	void FixedUpdate(){
		// The asset used uses the legacy animator, so the two states, idle and run, must be set by this script. Given
		// the input from the player, we change the animation accordingly
		if (!moving && (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.1F || Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.1F)) {
			anim.CrossFade ("run",.1f);
			moving = true;
		} else if (moving && (Mathf.Abs (Input.GetAxis ("Vertical")) < 0.1F && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.1F)) {
			anim.CrossFade ("idle",.1f);
			moving = false;
		}
	}
}
