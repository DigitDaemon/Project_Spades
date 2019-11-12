/***************************************************************
* file: MainMenuButton.cs
* author: Team Rogue Fence
* class: CS 470 - Game Development
*
* assignment: program 3
* date last modified: 5/29/2018
*
* purpose: This script allows for the player to go to the main menu
* when the main menu buttton is pressed.
*
****************************************************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {

	// method: StartGame
	// purpose: Loads the main menu scene when the menu button
	// is pressed.
	public void StartGame () {
		Application.LoadLevel("Menu");
	}
	
}
