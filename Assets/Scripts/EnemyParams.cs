using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams
{
    private int _health;
    private float _speed;
    private float _spawnRate;
    private int _orcSpawnChance;

    public EnemyParams() 
    {
        _health = 1;
        _speed = 2;
        _spawnRate = 5;
        _orcSpawnChance = 70;
    }

    public int Health 
    {
        get { return _health; }
        set { _health = value; }
    }
    public float Speed 
    { 
        get { return _speed; }
        set { _speed = value; }
    }
    public float SpawnRate 
    {
        get { return _spawnRate; }
        set { _spawnRate = value; }
    }
    public int OrcSpawnChance
    {
        get { return _orcSpawnChance; }
        set { _orcSpawnChance = value; }
    }
}
