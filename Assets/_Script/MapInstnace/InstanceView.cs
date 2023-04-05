using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstanceView : MonoBehaviour
{
    [SerializeField] float viewDistance;
    [SerializeField] LayerMask viewLayer;
    [SerializeField] int viewCount;

    //
    int targetCount;
    Collider2D[] targets;

    public bool viewedTarget { get; private set; }

    void Start()
    {
        targets = new Collider2D[viewCount];
    }
    void Update()
    {
        viewedTarget = ViewCheck();
    }
    bool ViewCheck()
    {
        targetCount = Physics2D.OverlapCircleNonAlloc(transform.position, viewDistance, targets, viewLayer);

        return targetCount > 0;
    }
    public T GetRandomTarget<T>() where T : MonoBehaviour
    {
        return targets[Random.Range(0, targetCount)].GetComponent<T>();
    }
    public T GetClosedTarget<T>() where T : MonoBehaviour
    {
        Collider2D target = null;
        float distance = float.MaxValue;

        for (int i = 0; i < targetCount; i++)
        {
            float checkDis = (targets[i].transform.position - transform.position).sqrMagnitude;
            if (checkDis < distance)
            {
                distance = checkDis;
                target = targets[i];
            }
        }

        return target.GetComponent<T>();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

}
