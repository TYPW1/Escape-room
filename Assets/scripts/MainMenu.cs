using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class represents the main menu of our game.
public class MainMenu : MonoBehaviour
{
    // String variable to store the name of the scene we want to load.
    public string scenename;

    // The Update method is called once per frame.
    void Update()
    {
        // If the player presses the 'P' key, load the specified scene.
        if(Input.GetKey(KeyCode.P)){
            SceneManager.LoadScene(scenename);
        }

        // If the player presses the 'Escape' key, quit the application.
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
