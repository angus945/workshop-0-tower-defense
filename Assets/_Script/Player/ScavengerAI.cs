using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerAI : UnitAI
{

    InstanceMovement movement;
    InstanceAttack attack;
    InstanceView view;

    void Awake()
    {
        movement = GetComponent<InstanceMovement>();
        attack = GetComponent<InstanceAttack>();
        view = GetComponent<InstanceView>();
    }
    void Update()
    {
        if (!attack.isAttacking)
        {
            Director();
        }
    }

    void Director()
    {
        if(attack.haveTarget && base.groupState == GroupState.Idle)
        {
            movement.MoveToTarget(attack.targetPosition);
        }
        else
        {
            attack.RemoveTarget();
            movement.MoveToTarget(base.standPoint);
        }
    }

}
