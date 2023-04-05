using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicItem : MonoBehaviour
{
    [SerializeField] ResoucesData reliceResources;

    void Awake()
    {
        GetComponent<MapInstance>().onHealthZeroing += AddResources;
    }
    void AddResources(MapInstance instance)
    {
        PlayerResources.AddResources(reliceResources, 1);

        Destroy(gameObject);
    }

}
