using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMovement : MonoBehaviour
{
    public Action<Vector3> onMoved;
    [SerializeField] float speed;

    public bool isMoving;
    public void LateUpdate()
    {
        isMoving = false;
    }

    public void MoveDirection(Vector3 direction)
    {
        direction = direction.normalized;

        transform.position += direction.normalized * speed * Time.deltaTime;
        onMoved?.Invoke(direction);

        isMoving = true;
    }

    public bool MoveToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        bool moving = direction.sqrMagnitude > 0.1f;

        if (moving)
        {
            MoveDirection(direction);
            isMoving = true;
        }

        return moving;
    }
}
