// Importing the required namespaces
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// The 'jumpscare' class inherits from MonoBehaviour to allow it to be attached to a game object
public class jumpscare : MonoBehaviour
{
   // The 'scenename' public string variable allows the user to specify the name of the scene to be loaded 
   // in the Unity Inspector
   public string scenename;

   // OnTriggerEnter is a MonoBehaviour method that is called when a Collider enters the trigger
   void OnTriggerEnter(Collider other){
    // Check if the tag of the object that entered the trigger is 'Player'
    if(other.CompareTag("Player")){
        // If it is, load the scene specified by the 'scenename' variable
        SceneManager.LoadScene(scenename);
    }
   }
}
