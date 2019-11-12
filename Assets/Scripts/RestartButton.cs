/***************************************************************
* file: RestartButton.cs
* author: Team Rogue Fence
* class: CS 470 - Game Development
*
* assignment: program 3
* date last modified: 5/29/2018
*
* purpose: This script allows for the player to restart the game
* when the restart buttton is pressed.
*
****************************************************************/ 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

	// method: StartGame
	// purpose: Loads the game level scene so that the game starts
	// from the beginning when restart is pressed.
	public void StartGame () {
		Application.LoadLevel("Spades_Map");
	}

}
