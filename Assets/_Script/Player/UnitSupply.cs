using UnityEngine;

public class UnitSupply : MonoBehaviour
{
    [SerializeField] ResoucesData supplyResources;

    [SerializeField] float supplyRange;
    [SerializeField] float supplyTime;
    [SerializeField] LayerMask supplyLayer;

    Collider2D[] supplyTargets = new Collider2D[300];
    float supplyTimer;

    void Update()
    {
        if (supplyTimer < supplyTime)
        {
            supplyTimer += Time.deltaTime;

            return;
        }
        else supplyTimer = 0;

        int targetCount = Physics2D.OverlapCircleNonAlloc(transform.position, supplyRange, supplyTargets, supplyLayer);

        for (int i = 0; i < targetCount; i++)
        {
            UnitAI unit = supplyTargets[i].GetComponent<UnitAI>();
            int supplyCount = PlayerResources.GetResourcesCount(supplyResources);
            int consume = unit.SendSupply(supplyCount);

            PlayerResources.RemoveResources(supplyResources, consume);
        }



    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, supplyRange);

    }

}
