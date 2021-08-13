using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int experienceYield;
    public Enemy(string name, Stats stats)
    {
        Name = name;
        this.Stats = stats;
    }
}
