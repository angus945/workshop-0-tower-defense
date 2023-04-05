using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstanceAttack : MonoBehaviour
{
    [SerializeField] float attackRange;

    [SerializeField] int damage;
    [SerializeField] float attackTime;
    [SerializeField] bool randomTarget;
    float attackTimer;

    MapInstance attackTarget;
    public bool haveTarget { get => attackTarget != null; }
    public Vector3 targetDirection { get => attackTarget.transform.position - transform.position; }
    public Vector3 targetPosition { get => attackTarget.transform.position; }
    public float targetDistance { get => targetDirection.magnitude; }

    public bool isAttacking { get; private set; }

    InstanceView view;
    public Action onAttacked;

    void Awake()
    {
        view = GetComponent<InstanceView>();
    }
    void Update()
    {
        isAttacking = AttackTarget();

        if(view.viewedTarget)
        {
            SetTarget(randomTarget ? view.GetRandomTarget<MapInstance>() : view.GetClosedTarget<MapInstance>());
        }

        VaildTarget();
    }
    void VaildTarget()
    {
        if (attackTarget != null && !attackTarget.isAlive)
        {
            attackTarget = null;
            Debug.LogError("Death Target");
        }
    }
    void SetTarget(MapInstance target)
    {
        if (this.attackTarget != null) return;
        if (target == null) return;

        this.attackTarget = target;
    }
    public void RemoveTarget()
    {
        attackTarget = null;
    }

    bool AttackTarget()
    {
        if (attackTarget == null) return false;

        if(targetDistance < attackRange)
        {
            Debug.DrawLine(transform.position, attackTarget.transform.position, Color.yellow);

            if (attackTimer > attackTime)
            {
                attackTimer = 0;
                attackTarget.SendDamage(damage);

                onAttacked?.Invoke();
                Debug.DrawLine(transform.position, attackTarget.transform.position, Color.red, 0.1f);
            }

            attackTimer += Time.deltaTime;
            return true;
        }
        else
        {
            attackTimer = 0;
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
