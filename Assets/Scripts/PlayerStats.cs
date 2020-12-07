using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private int _kills;
    private int _deaths;
    private float _timeSinceLastHit;

    public PlayerStats() 
    {
        _kills = 0;
        _deaths = 0;
        _timeSinceLastHit = 0;
    }

    public int Kills 
    {
        get { return _kills; }
        set { _kills = value; }
    }

    public int Deaths 
    {
        get { return _deaths; }
        set { _deaths = value; }
    }

    public float TimeSinceLastHit
    {
        get { return _timeSinceLastHit; }
        set { _timeSinceLastHit = value; } 
    }
}
