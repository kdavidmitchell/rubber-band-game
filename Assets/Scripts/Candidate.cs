using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candidate 
{
    private GameObject _candidate;
    private double _fitness;
    public Candidate() 
    {
        _candidate = new GameObject();
        _fitness = 0;
    }

    public double Fitness 
    {
        get { return _fitness; }
        set { _fitness= value; }
    }
    public GameObject CandidateObject
    { 
        get { return _candidate; }
        set { _candidate = value; }
    }
}
