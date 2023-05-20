using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public GameObject monster; // Monster game object to enable

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("MainCamera")) // Assuming your player's tag is "MainCamera"
        {
            monster.SetActive(true); // Enable the monster
        }
    }
}

