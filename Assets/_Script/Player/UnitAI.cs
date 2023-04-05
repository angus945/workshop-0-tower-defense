using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAI : MonoBehaviour
{
    protected bool action;

    public void ActiveAtion(bool active)
    {
        action = active;
    }

    public Vector3 standPoint;

    public virtual int SendSupply(int supplyCount)
    {
        //MapInstance instance 
        //GetComponent<MapInstance>().heal

        return 0;
    }
}
