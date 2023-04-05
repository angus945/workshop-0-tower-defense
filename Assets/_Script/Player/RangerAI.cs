using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAI : UnitAI
{
    //TODO Run

    [SerializeField] Resources bullet;

    InstanceMovement movement;
    InstanceAttack attack;
    InstanceView view;

    void Awake()
    {
        movement = GetComponent<InstanceMovement>();
        attack = GetComponent<InstanceAttack>();
        view = GetComponent<InstanceView>();

        attack.onAttacked += () => bullet.count -= 1;
    }
    void Update()
    {
        attack.enabled = base.action && bullet.count > 0;
    }

    public override int SendSupply(int supplyCount)
    {
        return bullet.Fill(supplyCount);
    }
}
