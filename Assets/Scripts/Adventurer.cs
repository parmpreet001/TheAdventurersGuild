using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Entity
{
    public struct Bond
    {
        public string name;
        public float bondLevel;

        public Bond(string name, float bondLevel)
        {
            this.name = name;
            this.bondLevel = bondLevel;
        }
    }

    private int experience;
    private List<Bond> bonds = new List<Bond>();
    private float avgBond;

    public Adventurer(string name, Stats stats)
    {
        Name = name;
        this.Stats = stats;
    }

    public void AddBond(string name, float bondLevel)
    {
        bonds.Add(new Bond(name, bondLevel));
    }
    
    public void AddExperience(int experienceAmount)
    {
        experience += experienceAmount;
        if(experience >= 100)
        {
            Level++;
            experience -= 100;
            //TODO: Stat changes
        }
    }

    public void SetAvgBond()
    {
        float temp = 0;
        foreach(Bond bond in bonds)
        {
            temp += bond.bondLevel;
        }
        avgBond = temp / bonds.Count;
    }

    public float GetAtk()
    {
        return Stats.atk * avgBond;
    }

    public float GetTrt()
    {
        return Stats.trt * avgBond;
    }

    public float GetCmp()
    {
        return Stats.cmp * avgBond;
    }

    public float GetIntl()
    {
        return Stats.intl * avgBond;
    }

    public float GetWis()
    {
        return Stats.wis * avgBond;
    }
}
