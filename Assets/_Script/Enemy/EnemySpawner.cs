using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] ObjectPool<MapInstance> enemyPool = new ObjectPool<MapInstance>();

    void Start()
    {
        enemyPool.FillPool();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MapInstance enemy = enemyPool.Dequeue();
            enemy.transform.position = Vector3.up * 5;
        }

    }
}
