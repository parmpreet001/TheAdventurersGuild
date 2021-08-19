using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Entity
{
    private int experience;
    public float avgBond;
    public Dictionary<string, float> Bonds { get; private set; } = new Dictionary<string, float>();

    public Adventurer(string name, EntityStats stats)
    {
        base.entityName = name;
        this.stats = stats;
    }

    public void SetBondLevel(string name, float bondLevel)
    {
        if (Bonds.ContainsKey(name))
            Bonds[name] = bondLevel;
        else
            Bonds.Add(name, bondLevel);
    }
    
    public void AddExperience(int experienceAmount)
    {
        experience += experienceAmount;
        if(experience >= 100)
        {
            level++;
            experience -= 100;
            //TODO: Stat changes
        }
    }

    /// <summary> Calculate the average bond between this member and the given list of party members </summary>
    public void SetAvgBond(List<string> partyMembers)
    {
        avgBond = 0;
        if (partyMembers.Count == 0)
            throw new Exception("Error: Need at least one other party member to calculate avg bond");
        
        foreach(string partyMember in partyMembers)
        {
            avgBond += Bonds[partyMember];
        }
        avgBond /= partyMembers.Count;
    }

    public float GetAtk()
    {
        return stats.atk * avgBond;
    }

    public float GetTrt()
    {
        return stats.trt * avgBond;
    }

    public float GetCmp()
    {
        return stats.cmp * avgBond;
    }

    public float GetIntl()
    {
        return stats.intl * avgBond;
    }

    public float GetWis()
    {
        return stats.wis * avgBond;
    }

    public void PrintBondLevels()
    {
        Debug.Log(entityName + "'s bonds:");
        foreach (KeyValuePair<string,float> bond in Bonds)
        {
            Debug.Log(bond.Key + ", " + bond.Value);
        }
    }
}
