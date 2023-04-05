using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resources
{
    public ResoucesData data;
    public int count;
    public int max;

    public int Fill(int fillAmount)
    {
        int space = max - count;
        int fill = Mathf.Min(space, fillAmount);

        count += fill;

        return fill;
    }
}
public class PlayerResources : MonoBehaviour
{
    static PlayerResources instance;

    [SerializeField] List<Resources> resouces;

    void Awake()
    {
        instance = this;
    }

    public static bool CheckResources(ResoucesData data, int count)
    {
        Resources resources = instance.resouces.Find(n => n.data == data);
        return resources.count > count;
    }
    public static int GetResourcesCount(ResoucesData data)
    {
        Resources resources = instance.resouces.Find(n => n.data == data);
        return resources.count;
    }
    public static void AddResources(ResoucesData data, int count)
    {
        Resources resources = instance.resouces.Find(n => n.data == data);
        resources.count += count;
    }
    public static void RemoveResources(ResoucesData data, int count)
    {
        Resources resources = instance.resouces.Find(n => n.data == data);
        resources.count -= count;
    }
}
