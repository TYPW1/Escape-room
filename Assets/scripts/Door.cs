using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

public GameObject door_closed, door_opened, intText, lockedtext;
public AudioSource open, close;
public bool opened, locked;
public bool hasKey = false;  

void OnTriggerStay (Collider other) { 
    Debug.Log("Inside the trigger");
    if (other.CompareTag ("MainCamera")){
        if (opened == false) {
            if (locked == false){
                intText.SetActive (true);
                if (Input.GetKeyDown (KeyCode.E)) {
                    Debug.Log("E key pressed");
                    door_closed.SetActive (false);
                    door_opened.SetActive (true); 
                    intText.SetActive (false);
                    StartCoroutine (repeat ());
                    opened = true;
                }
            }
            else if (locked == true && hasKey == true) // Door is locked but player has the key
            {
                locked = false; // Unlock the door
                intText.SetActive (true);
                if (Input.GetKeyDown (KeyCode.E)) {
                    Debug.Log("E key pressed");
                    door_closed.SetActive (false);
                    door_opened.SetActive (true); 
                    intText.SetActive (false);
                    StartCoroutine (repeat ());
                    opened = true;
                }
            }
            else if (locked == true && hasKey == false) // Door is locked and player doesn't have the key
            {
                if (lockedtext != null) // Check if lockedtext is assigned before using it
                {
                    lockedtext.SetActive(true);
                }
            }
        }
    }
}

void OnTriggerExit (Collider other) { 
    if (other.CompareTag ("MainCamera")){
        intText.SetActive (false);
         if (lockedtext != null) // Check if lockedtext is assigned before using it
        {
            lockedtext.SetActive(false);
        }
    }
} 
IEnumerator repeat () {
    yield return new WaitForSeconds (4.0f);
    opened = false;
    door_closed.SetActive (true);
    door_opened.SetActive (false);
    close.Play();
    }
}