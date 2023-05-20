using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the player's interaction with a flashlight object in the game world.
public class lightscript : MonoBehaviour
{
    // GameObjects representing the flashlight on the ground, the prompt icon for interaction, 
    // and the flashlight as it appears when held by the player
    public GameObject flashlight_ground, initicon, flashlight_player;
    
    // Reference to the player's transform component, which we'll use to determine where the flashlight should go when dropped
    public Transform playerTransform;
    
    // Boolean flag indicating whether the player has picked up the flashlight
    private bool isFlashlightPicked = false;

    // Audio source to play when flashlight is picked up
    public AudioSource pickup;

    // Called every frame
    void Update()
    {
        Debug.Log("Update in lightscript");

        // If the 'L' key is pressed, log a message (this seems to be for debugging purposes)
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("F key pressed");
        }

        // If the flashlight is picked and 'L' key is pressed, drop the flashlight
        if (isFlashlightPicked && Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("F key pressed");
            
            // Position the flashlight slightly ahead of the player's current position
            flashlight_ground.transform.position = playerTransform.position + playerTransform.forward;
            
            // Enable the flashlight_ground object (make it visible) and disable the flashlight_player object (make it invisible)
            flashlight_ground.SetActive(true);
            flashlight_player.SetActive(false);
            
            // Update the state to reflect that the flashlight is no longer picked up
            isFlashlightPicked = false;
        }
    }

    // Called when another collider stays for one frame within a trigger
    void OnTriggerStay(Collider other)
    {
        Debug.Log("ontiggerstay in lightscript");
        
        // Check if the object that entered the trigger is tagged as "MainCamera" (assumed to represent the player)
        if(other.CompareTag("MainCamera"))
        {
            // Enable the interaction icon
            initicon.SetActive(true);
            
            // If the 'E' key is pressed and the flashlight isn't already picked, pick up the flashlight
            if(Input.GetKeyDown(KeyCode.E) && !isFlashlightPicked)
            {
                Debug.Log("Flashlight picked up");
                
                // Disable the flashlight_ground and interaction icon objects, and enable the flashlight_player object
                flashlight_ground.SetActive(false);
                initicon.SetActive(false);
                flashlight_player.SetActive(true);
                
                // Update the state to reflect that the flashlight is now picked up
                isFlashlightPicked = true;

                // Play flashlight pickup sound
                pickup.Play();
            }
        }
    }

    // Called when another collider exits the trigger
    void OnTriggerExit(Collider other)
    {
        // Check if the object that left the trigger is tagged as "MainCamera" (assumed to represent the player)
        if(other.CompareTag("MainCamera"))
        {
            // Disable the interaction icon
            initicon.SetActive(false);
        }
    }
}
