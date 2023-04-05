using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string idleName;
    [SerializeField] string walkName;
    [SerializeField] string attackName;

    InstanceAttack attack;
    InstanceMovement movement;

    void Awake()
    {
        attack = GetComponent<InstanceAttack>();
        movement = GetComponent<InstanceMovement>();
    }
    void Update()
    {
        if(attack != null && attack.isAttacking)
        {
            animator.Play(attackName);
        }
        else if(movement != null && movement.isMoving)
        {
            animator.Play(walkName);
        }
        else
        {
            animator.Play(idleName);
        }
    }
}
