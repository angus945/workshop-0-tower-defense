using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAI : MonoBehaviour
{
    public enum GroupState
    {
        Idle,
        Move,
    }
    public enum UnitState
    {
        Idle,
        Move,
        Attack,
    }

    protected GroupState groupState;
    protected UnitState state;

    public void ActiveAtion(GroupState state)
    {
        groupState = state;
    }

    public Vector3 standPoint;

    public virtual int SendSupply(int supplyCount)
    {
        //MapInstance instance 
        //GetComponent<MapInstance>().heal

        return 0;
    }
}
