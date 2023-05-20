using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public Transform target; // Player
    public float speed = 3f;

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate the rotation needed to point towards the target
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Apply the rotation to the monster
        transform.rotation = Quaternion.Euler(0f, -angle, 0f);

        // Move the monster towards the target
        transform.position += direction * speed * Time.deltaTime;
    }
}
