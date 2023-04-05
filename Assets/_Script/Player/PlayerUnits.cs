using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStorage
{
    public Resources unit;
    public ObjectPool<MapInstance> unitPool;
}
public class PlayerUnits : MonoBehaviour
{
    [SerializeField] UnitStorage[] idleUnits;
    [SerializeField] ObjectPool<UnitGroup> groupPool = new ObjectPool<UnitGroup>();

    void Start()
    {
        for (int i = 0; i < idleUnits.Length; i++)
        {
            idleUnits[i].unitPool.FillPool();
        }

        groupPool.FillPool();
    }

    void Update()
    {
        for (int i = 0; i < idleUnits.Length; i++)
        {
            UnitStorage unitStorage = idleUnits[i];

            if(PlayerResources.CheckResources(unitStorage.unit.data, unitStorage.unit.count))
            {
                PlayerResources.RemoveResources(unitStorage.unit.data, unitStorage.unit.count);

                CreateGroup(unitStorage);
            }
        }

    }

    public UnitGroup CreateGroup(UnitStorage storage)
    {
        UnitGroup group = groupPool.Dequeue();

        int unitCount = storage.unit.count;
        for (int i = 0; i < unitCount; i++)
        {
            MapInstance unit = storage.unitPool.Dequeue();
            group.AddUnit(unit);
        }

        return group;
    }

}
