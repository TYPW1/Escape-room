using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public Door doorScript;  // Reference to the Door script
    public GameObject initicon;  // The press E message
    public GameObject canvasToActivate;  // Assign this with your Canvas in the inspector
    public AudioSource pickup;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("MainCamera")) {
            initicon.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("MainCamera")) {
            if (Input.GetKeyDown(KeyCode.E)) {
                doorScript.hasKey = true;  // Set hasKey to true on the Door script
                canvasToActivate.SetActive(true);  // Activate the canvas
                Destroy(gameObject);  // Destroy the key
                pickup.Play();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("MainCamera")) {
            initicon.SetActive(false);
        }
    }
}
