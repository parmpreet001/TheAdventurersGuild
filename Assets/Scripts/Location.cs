using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    private const int minDangerLevel = 1;
    private const int maxDangerLevel = 10;

    public string locationName;
    private int dangerLevel;

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

    /// <summary>
    /// Returns true if this location is connected to another location of the given name
    /// </summary>
    public bool Search(string name)
    {
        foreach(Location location in connectedLocations)
        {
            if (name.Equals(location.locationName))
                return true;
        }
        return false;
    }

    /// <summary>Returns true if this location is connected to the given location</summary>
    public bool Search(Location location)
    {
        foreach(Location loc in connectedLocations)
        {
            if (loc.locationName.Equals(location.locationName))
                return true;
        }
        return false;
    }

}
