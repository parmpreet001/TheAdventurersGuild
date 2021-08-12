using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    private const int minDangerLevel = 1;
    private const int maxDangerLevel = 10;

    public string locationName;
    public int dangerLevel;

    public int DangerLevel
    {
        get { return dangerLevel; }
        set
        {
            if (value < minDangerLevel)
                dangerLevel = minDangerLevel;
            else if (value > maxDangerLevel)
                dangerLevel = maxDangerLevel;
            else
                dangerLevel = value;
        }
    }

    public List<Location> connectedLocations = new List<Location>();

    public Location(string locationName, int dangerLevel)
    {
        this.locationName = locationName;
        this.dangerLevel = dangerLevel;
    }
}
