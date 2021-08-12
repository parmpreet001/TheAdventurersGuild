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
    /// Attaches a new Location to an already existing location
    /// </summary>
    /// <param name="locationName">Name of the existing location</param>
    /// <param name="newLocation">New Location to be added</param>
    public void AddLocation(string locationName, Location newLocation)
    {
        if (root == null)
            throw new Exception("Exception: A root location has not been set");
        else
        {
            foreach(Location loc in locations)
            {
                if(loc.locationName.Equals(locationName))
                {
                    loc.connectedLocations.Add(newLocation);
                    if(!Search(newLocation.locationName))
                    {
                        locations.Add(newLocation);
                    }
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

        AddLocation("location 1", location2);
        AddLocation("location 1", location3);
        AddLocation("location 2", location4);
        AddLocation("location 2", location5);
        AddLocation("location 2", location6);
        AddLocation("location 3", location6);
        AddLocation("location 3", location7);
        AddLocation("location 6", location7);


    }
}
