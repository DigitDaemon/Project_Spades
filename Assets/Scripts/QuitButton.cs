/***************************************************************
* file: QuitButton.cs
* author: Team Rogue Fence
* class: CS 470 - Game Development
*
* assignment: program 3
* date last modified: 5/29/2018
*
* purpose: This script allows for the player to quit the game
* when the quit buttton is pressed.
*
****************************************************************/ 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

	// method: StartGame
	// purpose: Quits the game when the quit button is pressed.
    public void Quit()
    {
        Application.Quit();
    }

}
