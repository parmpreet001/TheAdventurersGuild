using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Entity
{
    private int experience;
    public Dictionary<string, float> Bonds { get; private set; } = new Dictionary<string, float>();

    public Adventurer(string name, EntityStats stats)
    {
        Name = name;
        this.Stats = stats;
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
            Level++;
            experience -= 100;
            //TODO: Stat changes
        }
    }

    /// <summary> Calculate the average bond between this member and the given list of party members </summary>
    public float GetAvgBond(List<string> partyMembers)
    {
        if (partyMembers.Count == 0)
            throw new Exception("Error: Need at least one other party member to calculate avg bond");
        float avgBond = 0;
        foreach(string partyMember in partyMembers)
        {
            avgBond += Bonds[partyMember];
        }
        return avgBond /= partyMembers.Count;
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

    public void PrintBondLevels()
    {
        Debug.Log(Name + "'s bonds:");
        foreach (KeyValuePair<string,float> bond in Bonds)
        {
            Debug.Log(bond.Key + ", " + bond.Value);
        }
    }
}
