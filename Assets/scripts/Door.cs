using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Door states and UI components
    public GameObject door_closed, door_opened, intText, lockedtext;
    // Audio sources for opening and closing sounds
    public AudioSource open, close;
    // State of the door (opened/closed) and its lock
    public bool opened, locked;
    // State of the player having a key
    public bool hasKey = false;  

    // Triggers when player is near the door (stays within the collider)
    void OnTriggerStay (Collider other) { 
        // Check if the object that collided with the door is the player
        if (other.CompareTag ("MainCamera")){
            // Check if the door is not already open
            if (opened == false) {
                // Check if the door is unlocked
                if (locked == false){
                    // Show the interaction text
                    intText.SetActive (true);
                    // Open the door if 'E' key is pressed
                    if (Input.GetKeyDown (KeyCode.E)) {
                        door_closed.SetActive (false);
                        door_opened.SetActive (true); 
                        intText.SetActive (false);
                        // Start a coroutine to automatically close the door after some time
                        StartCoroutine (repeat ());
                        opened = true;
                    }
                }
                // Door is locked but player has the key
                else if (locked == true && hasKey == true) 
                {
                    locked = false; // Unlock the door
                    intText.SetActive (true);
                    // Open the door if 'E' key is pressed
                    if (Input.GetKeyDown (KeyCode.E)) {
                        door_closed.SetActive (false);
                        door_opened.SetActive (true); 
                        intText.SetActive (false);
                        // Start a coroutine to automatically close the door after some time
                        StartCoroutine (repeat ());
                        opened = true;
                    }
                }
                // Door is locked and player doesn't have the key
                else if (locked == true && hasKey == false) 
                {
                    // Show the locked door text if the text object is assigned
                    if (lockedtext != null) 
                    {
                        lockedtext.SetActive(true);
                    }
                }
            }
        }
    }

    // Triggers when player leaves the door's collider
    void OnTriggerExit (Collider other) { 
        if (other.CompareTag ("MainCamera")){
            // Hide the interaction text
            intText.SetActive (false);
            // Hide the locked door text if the text object is assigned
            if (lockedtext != null) 
            {
                lockedtext.SetActive(false);
            }
        }
    } 

    // Coroutine to close the door after a delay
    IEnumerator repeat () {
        // Wait for 4 seconds
        yield return new WaitForSeconds (4.0f);
        // Change door state to closed
        opened = false;
        door_closed.SetActive (true);
        door_opened.SetActive (false);
        // Play the door close sound
        close.Play();
    }
}
