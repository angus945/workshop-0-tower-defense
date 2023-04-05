using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    InstanceMovement movement;
    InstanceAttack attack;
    InstanceView view;

    void Awake()
    {
        movement = GetComponent<InstanceMovement>();
        attack = GetComponent<InstanceAttack>();
        view = GetComponent<InstanceView>();
    }
    void Update()
    {
        if (!attack.isAttacking)
        {
            Director();
        }
    }

    void Director()
    {
        Vector3 direction = attack.haveTarget ? attack.targetDirection : -transform.position;

        movement.MoveDirection(direction);
    }
}
