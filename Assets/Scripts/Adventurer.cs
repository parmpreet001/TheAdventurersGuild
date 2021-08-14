using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Entity
{
    private int experience;
    public Dictionary<string, float> bonds = new Dictionary<string, float>();    

    public Adventurer(string name, EntityStats stats)
    {
        Name = name;
        this.Stats = stats;
    }

    public void AddBond(string name, float bondLevel)
    {
        bonds.Add(name, bondLevel);
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

    public void GetAvgBond(params string[] partyMembers)
    {
        float avgBond = 0;
        foreach(string partyMember in partyMembers)
        {
            avgBond += bonds[partyMember];
        }
        avgBond /= partyMembers.Length;
    }

    public float GetAtk(float avgBond)
    {
        return Stats.atk * avgBond;
    }

    public float GetTrt(float avgBond)
    {
        return Stats.trt * avgBond;
    }

    public float GetCmp(float avgBond)
    {
        return Stats.cmp * avgBond;
    }

    public float GetIntl(float avgBond)
    {
        return Stats.intl * avgBond;
    }

    public float GetWis(float avgBond)
    {
        return Stats.wis * avgBond;
    }
}
