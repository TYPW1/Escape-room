using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class provides the functionality for exiting the game.
public class exitgame : MonoBehaviour
{
    // Update is called once per frame. This is a built-in Unity function that 
    // runs every frame of the game.
    void Update()
    {
        // Check for the Escape key being pressed.
        // If it is pressed, then the game application is requested to quit.
        // Note that this will not work in the Unity editor - it is intended for the built game.
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
