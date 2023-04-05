using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildInstance
{
    public ObjectPool<MapInstance> buildingPool;
    public Resources[] costs;
}
public class PlayerBuilder : MonoBehaviour
{

    [SerializeField] BuildInstance[] builds;

    void Start()
    {
        for (int i = 0; i < builds.Length; i++)
        {
            builds[i].buildingPool.FillPool();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BuildInstance(builds[0], pos);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BuildInstance(builds[1], pos);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BuildInstance(builds[2], pos);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BuildInstance(builds[3], pos);
        }
    }

    public bool VaildBuild(BuildInstance product)
    {
        for (int i = 0; i < product.costs.Length; i++)
        {
            Resources cost = product.costs[i];

            if(!PlayerResources.CheckResources(cost.data, cost.count))
            {
                return false;
            }
        }

        return true;
    }
    public void BuildInstance(BuildInstance build, Vector3 position)
    {
        for (int i = 0; i < build.costs.Length; i++)
        {
            Resources cost = build.costs[i];

            PlayerResources.RemoveResources(cost.data, cost.count);
        }

        MapInstance buildInstance =  build.buildingPool.Dequeue();
        buildInstance.transform.position = position;
        //Instantiate(build.building, position, Quaternion.identity);
    }
}
