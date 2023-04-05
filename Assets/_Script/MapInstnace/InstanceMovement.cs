using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMovement : MonoBehaviour
{
    [SerializeField] float speed;

    public void MoveDirection(Vector3 direction)
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    public bool MoveToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        bool moving = direction.sqrMagnitude > 0.1f;

        if (moving)
        {
            MoveDirection(direction);
        }

        return moving;
    }
}
