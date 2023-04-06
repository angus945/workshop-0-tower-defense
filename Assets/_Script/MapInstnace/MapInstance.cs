using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstance : MonoBehaviour, IPoolObject
{
    public bool isAlive { get => health > 0; }

    [SerializeField] int maxHealth;
    [SerializeField] int _health;
    public int health 
    { 
        get => _health; 
        set 
        { 
            _health = Mathf.Clamp(value, 0, maxHealth); 
            onHealthUpdated?.Invoke(_health);

            if (_health <= 0)
            {
                onHealthZeroing?.Invoke(this);
                triggerRecycle?.Invoke();

                Debug.LogError("Death", this);
            }
        } 
    }

    public Action<int> onHealthUpdated;
    public Action<MapInstance> onHealthZeroing;

    public void SendDamage(int damage)
    {
        health -= damage;
    }

    //IPoolObject
    public Action triggerRecycle { get; set; }
    void IPoolObject.OnRecycle()
    {

    }
    void IPoolObject.OnActive()
    {
        _health = maxHealth;
    }
}
