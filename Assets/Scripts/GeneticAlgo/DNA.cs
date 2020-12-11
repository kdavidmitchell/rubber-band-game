using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{
    // 0 - speed
    // 1 - size
    private List<double> _genes = new List<double>();
    private int _dnaLength = 0;
    private int _maxValue = 0;
    
    public DNA(int length, int value) 
    {
        _dnaLength = length;
        _maxValue = value;
        SetRandom();
    }
    // The actual fitness function here.
    // enemyfitness = (10000/D(player, enemy)) - 10000*Damage(player);
    public void SetRandom() 
    {
        _genes.Clear();
        for (int i = 0; i < _dnaLength; i++) 
        {
            _genes.Add(Random.Range(0, _maxValue));
        }
    }
    public void SetInt(int pos, int value) 
    {
        _genes[pos] = value;
    }
    // bring up hitbox size. That way we at least have two things to combine
    public void Combine(DNA d1, DNA d2)
    {
        for (int i = 0; i < _dnaLength; i++)
        {
            double c = d1._genes[i];
            c += d2._genes[i];
            c /= 2;
        }
    }

    public void Mutate()
    {
        _genes[Random.Range(0, _dnaLength)] = Random.Range(0, _maxValue);
    }

    public double GetGene(int pos) 
    {
        return _genes[pos];
    }
}
