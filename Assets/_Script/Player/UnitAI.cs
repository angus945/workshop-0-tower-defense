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

    protected GroupState groupState = GroupState.Idle;
    protected UnitState state = UnitState.Idle;

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
