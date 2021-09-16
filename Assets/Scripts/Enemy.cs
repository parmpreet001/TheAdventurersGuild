using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int experienceYield;
    public Enemy(string name, EntityStats stats)
    {
        entityName = name;
        this.stats = stats;
    }

    //Copy constructor
    public Enemy(Enemy enemy)
    {
        entityName = enemy.entityName;
        stats = new EntityStats(enemy.stats);
    }
}
