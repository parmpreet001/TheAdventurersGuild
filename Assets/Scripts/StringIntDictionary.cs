using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

/// <summary>
/// Unity can't expose dictionaries in the inspector so i made my own dictionary lol
/// Functionality is limited compared to actual dictionaries, but we can add those as needed
/// </summary>
public class StringIntDictionary
{
    [System.Serializable]
    private class Item
    {
        public string name;
        public int amount;
        public int minValue;
        public int maxValue;

        public Item(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
            minValue = 0;
            maxValue = 100;
        }

        public Item(string name, int amount, int minValue, int maxValue)
        {
            this.name = name;
            this.amount = amount;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }

    [SerializeField]
    private List<Item> items = new List<Item>();

    /// <summary>
    /// Will attempt to add an item to the list of items. If an item already exists, the function will
    /// simply modify the value
    /// </summary>
    /// <param name="name">Name of the item to be added</param>
    /// <param name="amount">Amount of the item to add/subtract</param>
    public void AddItem(string name, int amount)
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
                item.amount += amount;
            }
        }

        //if no item with the given name was found, add it to items
        if (!itemAlreadyExists)
        {
            items.Add(new Item(tempName, amount));
        }
    }

    /// <summary>
    /// Will attempt to add an item to the list of items. If an item already exists, the function will
    /// simply modify the value.
    /// </summary>
    /// <param name="name">Name of the item to be added</param>
    /// <param name="amount">Amount of the item to add/subtract</param>
    /// <param name="minValue">Lowest value that can be set</param>
    /// <param name="maxValue">Highest value that can be set</param>
    public void AddItem(string name, int amount, int minValue, int maxValue)
    {
        bool itemAlreadyExists = false;

        string tempName = name.Trim();
        tempName = tempName.ToLower();

        foreach (Item item in items)
        {
            if (item.name.Equals(tempName))
            {
                itemAlreadyExists = true;
                item.amount += amount;
            }
        }

        if (!itemAlreadyExists)
        {
            items.Add(new Item(tempName, amount, minValue, maxValue));
        }
    }
}
