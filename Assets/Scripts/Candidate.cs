using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candidate 
{
    private float _speed;
    private float _spawnRate;
    private double _fitness;
    public Candidate() 
    {
        _speed = 0;
        _fitness = 0;
    }

    public double Fitness 
    {
        get { return _fitness; }
        set { _fitness = value; }
    }
    public float SpawnRate 
    {
        get { return _spawnRate; }
        set { _spawnRate = value; }
    }
    public float Speed
    { 
        get { return _speed; }
        set { _speed = value; }
    }
}
