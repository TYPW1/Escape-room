using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class makes a monster follow a target (like the player)
public class MonsterFollow : MonoBehaviour
{
    public Transform target; // Reference to the target (usually the player) the monster should follow
    public float speed = 3f; // Speed at which the monster moves towards the target

    // The Unity engine calls this function once per frame
    void Update()
    {
        // Calculate the direction vector from the monster's current position to the target's position, and normalize it
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate the angle (in degrees) that the monster should rotate to face the target
        // This is done by taking the inverse tangent (atan) of the direction's x/z components, converting it from radians to degrees
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Rotate the monster by setting its rotation to a new Quaternion representing the desired rotation
        // Notice the negative sign in front of the angle. This is because Unity's y-axis rotation is clockwise, while atan2 gives counter-clockwise angles
        transform.rotation = Quaternion.Euler(0f, -angle, 0f);

        // Move the monster towards the target at the defined speed. We multiply by Time.deltaTime to ensure smooth movement regardless of frame rate
        transform.position += direction * speed * Time.deltaTime;
    }
}
