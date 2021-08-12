using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
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

    public string Name { get; private set; }
    public Stats Stats { get; private set; }
    private List<Bond> bonds = new List<Bond>();
    private int level;
    private int experience;

    public Adventurer(string name, Stats stats)
    {
        Name = name;
        this.Stats = stats;
    }

    public void AddBond(string name, float bondLevel)
    {
        bonds.Add(new Bond(name, bondLevel));
    }
    


}
