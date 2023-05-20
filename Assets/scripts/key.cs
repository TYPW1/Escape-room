using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to a key object, which can be picked up to unlock a door
public class key : MonoBehaviour
{
    public Door doorScript;  // Reference to the Door script on the door this key opens
    public GameObject initicon;  // UI prompt that displays a message to press E to pick up the key
    public GameObject canvasToActivate;  // Another UI canvas to display when the key is picked up
    public AudioSource pickup;  // Audio to play when the key is picked up

    // Triggered when player enters the collider of the key
    void OnTriggerEnter(Collider other) {
        // Check if the collider belongs to the player's camera
        if (other.CompareTag("MainCamera")) {
            // Display the pickup prompt
            initicon.SetActive(true);
        }
    }

    // Triggered while the player stays within the collider of the key
    void OnTriggerStay(Collider other) {
        // Check if the collider belongs to the player's camera
        if (other.CompareTag("MainCamera")) {
            // Check if player presses 'E' to pick up the key
            if (Input.GetKeyDown(KeyCode.E)) {
                // Mark that the player has picked up the key
                doorScript.hasKey = true;
                // Display the UI canvas
                canvasToActivate.SetActive(true);
                // Destroy the key object in the scene
                Destroy(gameObject);
                // Play the pickup sound
                pickup.Play();
            }
        }
    }

    // Triggered when player leaves the collider of the key
    void OnTriggerExit(Collider other) {
        // Check if the collider belongs to the player's camera
        if (other.CompareTag("MainCamera")) {
            // Hide the pickup prompt
            initicon.SetActive(false);
        }
    }
}
