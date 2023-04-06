using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroup : MonoBehaviour, IPoolObject
{
    InstanceMovement movement;
    Vector3 destination;

    [Space]
    [SerializeField] Transform targetIcon;
    [SerializeField] Vector3[] standPoints;

    List<UnitAI> units = new List<UnitAI>();

    void Awake()
    {
        movement = GetComponent<InstanceMovement>();
    }
    void Start()
    {
        //view.Initial(transform, 5);
    }
    void Update()
    {
        if (movement.MoveToTarget(destination))
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].ActiveAtion(UnitAI.GroupState.Move);
                units[i].standPoint = transform.position + standPoints[i];
                //TODO calculate stand point
            }
        }
        else
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].ActiveAtion(UnitAI.GroupState.Idle);
            } 
        }
    }
    void LateUpdate()
    {
        targetIcon.position = destination;
    }

    public void AddUnit(MapInstance unit)
    {
        unit.transform.parent = transform;
        unit.transform.position = transform.position + standPoints[units.Count];

        unit.onHealthZeroing += RemoveUnit;

        units.Add(unit.GetComponent<UnitAI>());
    }
    public void SetDestination(Vector3 target)
    {
        this.destination = target;
    }

    void RemoveUnit(MapInstance unit)
    {
        unit.onHealthZeroing -= RemoveUnit;
        units.Remove(unit.GetComponent<UnitAI>());

        if(units.Count == 0)
        {
            triggerRecycle.Invoke();
        }
    }

    //IPoolObject
    public Action triggerRecycle { get; set; }
    void IPoolObject.OnRecycle() { }
    void IPoolObject.OnActive() { }
}
