using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines a trigger which, when the player enters it,
// activates a Monster GameObject in the scene.
public class MonsterTrigger : MonoBehaviour
{
    // Public GameObject reference to the Monster in the scene.
    // This should be set in the Inspector by dragging the Monster GameObject to this field.
    public GameObject monster; 

    // This method is called when another collider enters this object's trigger zone.
    // It's a Unity-defined method that works automatically with trigger colliders.
    void OnTriggerEnter(Collider other)
    {
        // We check if the collider that entered the trigger zone is tagged as "MainCamera".
        if (other.CompareTag("MainCamera"))
        {
            // If the player has entered the trigger zone, we activate the Monster GameObject.
            // The SetActive method enables all components of the GameObject in the scene.
            // This means that if the Monster was previously inactive, it will become active and start executing its own logic (assuming it has scripts attached).
            monster.SetActive(true); 
        }
    }
}
