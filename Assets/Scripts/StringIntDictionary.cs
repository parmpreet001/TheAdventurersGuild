using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

/// <summary>
/// Unity can't expose dictionaries in the inspector so i made my own dictionary lol
/// Functionality is limited compared to actual dictionaries, but we can add those as needed
/// This dictionary will be used for faction resources, attributes, and attribute opinions
/// </summary>
public class StringIntDictionary
{
    private bool hasGlobalMin, hasGlobalMax; //Whether or not this dictionary has lower/upper bounds for int values
    private int globalMin, globalMax; //Lower and upper bounds for every int value inserted in this dictionary

    [System.Serializable]
    private class Item
    {
        public string name;
        public int amount;

        public Item(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }

    [SerializeField]
    private List<Item> items = new List<Item>();

    public StringIntDictionary(bool hasGlobalMin, bool hasGlobalMax, int globalMin = 0, int globalMax = 0)
    {
        this.hasGlobalMin = hasGlobalMin;
        this.hasGlobalMax = hasGlobalMax;
        this.globalMin = globalMin;
        this.globalMax = globalMax;
    }

    /// <summary>
    /// Will attempt to add an item to the list of items. If an item already exists, the function will
    /// modify the value. Not case sensitive.
    /// </summary>
    /// <param name="name">Name of the item to be added</param>
    /// <param name="amount">Amount of the item to add/subtract</param>
    public void Add(string name, int amount)
    {
        bool itemAlreadyExists = false;

        //Trim white spaces at the start/end of name, then convert to lower case. This will make it so that 
        //captilization will not be a concern when adding/changing attributes
        string tempName = name.Trim();
        tempName = tempName.ToLower();

        //If there is already an item in items with the given name, modify the amount
        foreach(Item item in items)
        {
            if (item.name.Equals(tempName))
            {
                itemAlreadyExists = true;
                if (!hasGlobalMin && !hasGlobalMax)
                    item.amount += amount;
                else
                {
                    if (hasGlobalMin && item.amount + amount < globalMin)
                        item.amount = globalMax;
                    else if (hasGlobalMax && item.amount + amount > globalMax)
                        item.amount = globalMin;
                    else
                        item.amount += amount;
                }
            }
        }

        //if no item with the given name was found, add it to items
        if (!itemAlreadyExists)
        {
            if(!hasGlobalMin && !hasGlobalMax)
                items.Add(new Item(tempName, amount));
            else
            {
                if (hasGlobalMin && amount < globalMin)
                    items.Add(new Item(tempName, globalMin));
                else if (hasGlobalMax && amount > globalMax)
                    items.Add(new Item(tempName, globalMax));
                else
                    items.Add(new Item(tempName, amount));
            }
        }
    }

    public void SetGlobalMin(int min)
    {
        hasGlobalMin = true;
        globalMin = min;
    }

    public void SetGlobalMax(int max)
    {
        hasGlobalMax = true;
        globalMax = max;
    }

    /// <summary>
    /// Returns value of the given item
    /// </summary>
    public int GetValue(string name)
    {
        string tempName = name.Trim();
        name = name.ToLower();
        foreach(Item item in items)
        {
            if (item.name.Equals(name))
                return item.amount;
        }
        throw new Exception("Error: No such item with the name " + name + " exists within this dictionary");
    }

}
