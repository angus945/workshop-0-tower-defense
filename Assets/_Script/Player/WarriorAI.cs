using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : UnitAI
{
    InstanceMovement movement;
    InstanceAttack attack;
    InstanceView view;

    void Awake()
    {
        movement = GetComponent<InstanceMovement>();
        attack = GetComponent<InstanceAttack>();
        view = GetComponent<InstanceView>();

        //attack.onAttacked += () => bullet.count -= 1;
    }
    void Update()
    {
        //attack.enabled = groupState == GroupState.Idle && bullet.count > 0;
    }

    public override int SendSupply(int supplyCount)
    {
        //return bullet.Fill(supplyCount);

        return 0;
    }
}
