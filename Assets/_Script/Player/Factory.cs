using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Resources productMaterial;

    [SerializeField] ResoucesData productResources;
    [SerializeField] float productTime;
    [SerializeField] int prodcutCount;

    float timer;

    void Start()
    {
        
    }
    void Update()
    {
        if(productMaterial.data != null)
        {
            if (!PlayerResources.CheckResources(productMaterial.data, productMaterial.count)) return;
        }

        if (timer < productTime)
        {
            timer += Time.deltaTime;
            return;
        }
        else timer = 0;

        PlayerResources.AddResources(productResources, prodcutCount);

        if (productMaterial.data != null)
        {
           PlayerResources.RemoveResources(productMaterial.data, productMaterial.count);
        }
    }
}
