using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public string locationName;
    public int DangerLevel { get; private set; }

    //used for path finding
    public int dangerSum; //The total danger level of the path leading to this node
    public bool visited; 
    public int distance = 100;

    [SerializeField]
    public Location prev; 

    public List<string> connectedLocations = new List<string>();
    public Dictionary<string, int> distances = new Dictionary<string, int>(); //distances between other nodes

    public Location(string locationName, int dangerLevel)
    {
        this.locationName = locationName;
        this.DangerLevel = dangerLevel;
    }

    /// <summary> Returns true if this location is connected to another location of the given name </summary>
    public bool Search(string name)
    {
        foreach(string location in connectedLocations)
        {
            if (name.Equals(location))
                return true;
        }
        return false;
    }

    /// <summary> Returns true if this location is connected to the given location </summary>
    public bool Search(Location location)
    {
        foreach(string loc in connectedLocations)
        {
            if (loc.Equals(location.locationName))
                return true;
        }
        return false;
    }

}
