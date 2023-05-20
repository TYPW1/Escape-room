using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject sitText;  // Assign this with a Canvas that says "Press E to sit"
    public GameObject standText;  // Assign this with a Canvas that says "Press E to stand up"
    public Transform sitPosition;  // Assign this with an empty GameObject located where you want the player to sit
    private bool playerIsSitting = false;

    SC_FPSController playerScript;  // The player's script, which we'll use to disable/enable player movement

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            sitText.SetActive(true);
            playerScript = other.gameObject.GetComponent<SC_FPSController>();  // Grab a reference to the player's script
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!playerIsSitting)
                {
                    // Player wants to sit down
                    other.transform.position = sitPosition.position;  // Move the player to the chair
                    other.transform.root.GetComponent<SC_FPSController>().canMove = false;  // Disable player movement
                    playerIsSitting = true;
                    sitText.SetActive(false);
                    standText.SetActive(true);
                }
                else
                {
                    // Player wants to stand up
                    other.transform.position = sitPosition.position + sitPosition.forward;  // Move the player slightly forward
                    other.transform.root.GetComponent<SC_FPSController>().canMove = true;  // Enable player movement
                    playerIsSitting = false;
                    standText.SetActive(false);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            sitText.SetActive(false);
        }
    }
}
