using UnityEngine;

[System.Serializable]
class EnemySpawn
{
    public int spawnMin;
    public int spawnMax;
    public ObjectPool<MapInstance> spawnEnemy;
    public Transform[] spawnPoints;

    public void Initial()
    {
        spawnEnemy.FillPool();
    }
    public void RandomSpawn()
    {
        Vector3 poisition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        int spawnCount = Random.Range(spawnMin, spawnMax + 1);

        for (int i = 0; i < spawnCount; i++)
        {
            MapInstance enemy = spawnEnemy.Dequeue();
            enemy.transform.position = poisition;
        }
    }
}
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawn[] spawn;

    [SerializeField] float spawnTime;
    float timer;

    void Start()
    {
        for (int i = 0; i < spawn.Length; i++)
        {
            spawn[i].Initial();
        }
    }
    void Update()
    {
        if (timer > spawnTime)
        {
            SpawnRandom();
            timer = 0;
        }
        else timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandom();
        }

    }

    void SpawnRandom()
    {
        EnemySpawn spawnData = spawn[Random.Range(0, spawn.Length)];

        spawnData.RandomSpawn();
    }
}
