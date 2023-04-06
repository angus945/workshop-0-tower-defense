using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceEffect : MonoBehaviour
{
    MapInstance instance;
    InstanceAttack attack;
    InstanceMovement movement;

    [SerializeField] GameObject deathEffect;

    void Awake()
    {
        instance = GetComponent<MapInstance>();
        attack = GetComponent<InstanceAttack>();
        movement = GetComponent<InstanceMovement>();
    }
    void Start()
    {
        if(deathEffect !=null)
        {
            instance.onHealthZeroing += (_) =>
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            };
        }
    }

}
