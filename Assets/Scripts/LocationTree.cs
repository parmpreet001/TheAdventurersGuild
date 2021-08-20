using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTree : MonoBehaviour
{
    private Location root;
    [SerializeField]
    private List<Location> locations = new List<Location>();


    /// <summary>
    /// Creates an undirected link between two locations
    /// </summary>
    /// <param name="parentLocationName">Name of the parent location</param>
    /// <param name="childLocation">New Location to be added to parrent</param>
    public void AddLocation(string parentLocationName, Location childLocation, float edgeWeight)
    {
        if (root == null)
            throw new Exception("Exception: A root location has not been set");
        else
        {
            foreach(Location loc in locations)
            {
                //If the parent location exists
                if(loc.locationName.Equals(parentLocationName))
                {
                    if (loc.Search(childLocation))
                        throw new Exception("Exception: The connection that you are trying to add already exists");
                    //Adds link from parent location to child location
                    loc.connectedLocations.Add(childLocation.locationName);
                    //If child location does not already exist in tree
                    if(!Search(childLocation.locationName))
                    {
                        locations.Add(childLocation);
                    }
                    //Adds link from child location to parent location
                    childLocation.connectedLocations.Add(parentLocationName);

                    loc.edgeWeights.Add(childLocation.locationName,edgeWeight);
                    childLocation.edgeWeights.Add(parentLocationName, edgeWeight);

                    return;
                }
            }
            throw new Exception("Exception: Cannot find location with specified name");
        }
    }

    public bool Search(string name)
    {
        foreach(Location loc in locations)
        {
            if(loc.locationName.Equals(name))
            {
                return true;
            }
        }
        return false;
    }

    public Location GetLocation(string name)
    {
        foreach (Location loc in locations)
        {
            if (loc.locationName.Equals(name))
            {
                return loc;
            }
        }
        throw new Exception("Exception: No location by that name was found");
    }

    public void SetRoot(Location location)
    {
        locations.Add(location);
        root = location;
    }



    //Just used for testing. Will get deleted later
    private void Start()
    {
        Location location1 = new Location("location 1", 1);
        Location location2 = new Location("location 2", 1);
        Location location3 = new Location("location 3", 1);
        Location location4 = new Location("location 4", 1);
        Location location5 = new Location("location 5", 1);
        Location location6 = new Location("location 6", 1);
        Location location7 = new Location("location 7", 1);

        SetRoot(location1);

        AddLocation("location 1", location2, 1);
        AddLocation("location 1", location3, 1);
        AddLocation("location 2", location4, 1);
        AddLocation("location 2", location5, 1);
        AddLocation("location 2", location6, 1);
        AddLocation("location 3", location6, 1);
        AddLocation("location 3", location7, 1);
        AddLocation("location 6", location7, 1);

        AddLocation("location 7", location6, 1);
    }
}
