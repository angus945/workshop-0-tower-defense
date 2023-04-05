using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    Action triggerRecycle { get; set; }
    void OnRecycle();
}

[System.Serializable]
public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
{
    [SerializeField] int fillCount;
    [SerializeField] Transform poolParent;
    [SerializeField] T prefab;
    Queue<T> pool;

    int idleInstance;

    public ObjectPool()
    {
        pool = new Queue<T>();
    }
    public void FillPool()
    {
        for (int i = 0; i < fillCount; i++)
        {
            T item = MonoBehaviour.Instantiate(prefab);
            item.triggerRecycle = () => RecylceObject(item);

            Enqueue(item);
        }
    }
    public void Enqueue(T item)
    {
        item.transform.parent = poolParent;
        item.gameObject.SetActive(false);

        pool.Enqueue(item);

        idleInstance++;
    }
    public T Dequeue()
    {
        T item = pool.Dequeue();

        item.transform.parent = null;
        item.gameObject.SetActive(true);

        idleInstance--;

        return item;
    }

    public void RecylceObject(T item)
    {
        item.OnRecycle();

        Enqueue(item);
    }
}
