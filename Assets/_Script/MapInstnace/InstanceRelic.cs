using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRelic : MonoBehaviour
{
    [SerializeField] MapInstance relicObject;
    [SerializeField] float relicProbability;

    MapInstance instance;

    void Start()
    {
        instance = GetComponent<MapInstance>();
        instance.onHealthZeroing += RelicCheck;
    }
    void RelicCheck(MapInstance instance)
    {
        if(Random.value <= relicProbability)
        {
            Instantiate(relicObject, transform.position, Quaternion.identity);
        }
    }
}
