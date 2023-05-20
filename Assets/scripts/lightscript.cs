using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscript : MonoBehaviour
{
    public GameObject flashlight_ground, initicon, flashlight_player;
    public Transform playerTransform; // Assign this with your player's transform in the inspector
    private bool isFlashlightPicked = false;
    public AudioSource pickup;

    void Update()
    {
        Debug.Log("Update in lightscript");

            // Check if 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("F key pressed");
        }
        // Rest of the Update method
        // Check if flashlight is picked and 'R' key is pressed to drop it
        if (isFlashlightPicked && Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("F key pressed");
            flashlight_ground.transform.position = playerTransform.position + playerTransform.forward; // Drops the flashlight in front of the player
            flashlight_ground.SetActive(true);
            flashlight_player.SetActive(false);
            isFlashlightPicked = false;
        }
    }

    void OnTriggerStay(Collider other){
        Debug.Log("ontiggerstay in lightscript");
        if(other.CompareTag("MainCamera")){
            initicon.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E) && !isFlashlightPicked){
                Debug.Log("Flashlight picked up");
                flashlight_ground.SetActive(false);
                initicon.SetActive(false);
                flashlight_player.SetActive(true);
                isFlashlightPicked = true;
                pickup.Play();
            }
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("MainCamera")){
            initicon.SetActive(false);
        }
    }
}
