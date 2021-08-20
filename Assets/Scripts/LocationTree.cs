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
    public void AddLocation(string parentLocationName, Location childLocation, int edgeWeight)
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


    public Stack<Location> FindPath(Location startLocation, Location targetLocation)
    {
        Stack<Location> path = new Stack<Location>();
        Location currentLoc = null;
        Location previousLoc = null;

        foreach(Location loc in locations)
        {
            loc.distance = 100;
            loc.visited = false;
            loc.prev = null;
        }

        startLocation.distance = 0;

        while(!targetLocation.visited)
        {
            Location loc = GetNearestUnexploredLocation();
            loc.visited = true;
            foreach(string neighbor in loc.connectedLocations)
            {
                if(loc.distance + loc.edgeWeights[neighbor] < GetLocation(neighbor).distance)
                {
                    GetLocation(neighbor).distance = loc.distance + loc.edgeWeights[neighbor];
                    GetLocation(neighbor).prev = loc;
                }
            }
        }

        Debug.Log("Shortest path between " + startLocation.locationName + " and " + targetLocation.locationName
            + " is " + targetLocation.distance);

        path.Push(targetLocation);
        while(path.Peek().locationName != startLocation.locationName)
        {
            path.Push(path.Peek().prev);
        }

        return path;
    }

    private Location GetNearestUnexploredLocation()
    {
        Location temp = null;
        foreach(Location loc in locations)
        {
            if(!loc.visited)
            {
                temp = loc;
                break;
            }
        }

        foreach(Location loc in locations)
        {
            if (!loc.visited && loc.distance < temp.distance)
                temp = loc;
        }
        return temp;
    }



    //Just used for testing. Will get deleted later
    private void Start()
    {
        Location locationA = new Location("location A", 1);
        Location locationB = new Location("location B", 1);
        Location locationC = new Location("location C", 1);
        Location locationD = new Location("location D", 1);
        Location locationE = new Location("location E", 1);
        Location locationF = new Location("location F", 1);
        Location locationG = new Location("location G", 1);

        SetRoot(locationA);

        AddLocation("location A", locationC, 3);
        AddLocation("location A", locationF, 2);
        AddLocation("location C", locationD, 4);
        AddLocation("location C", locationE, 1);
        AddLocation("location C", locationF, 2);
        AddLocation("location F", locationE, 3);
        AddLocation("location F", locationB, 6);
        AddLocation("location F", locationG, 5);
        AddLocation("location E", locationB, 2);
        AddLocation("location D", locationB, 1);
        AddLocation("location G", locationB, 2);

        Stack<Location> path = FindPath(locationA, locationB);

        Debug.Log("Path from location A to location B");
        while (path.Count > 0)
        {
            Debug.Log(path.Pop().locationName);
        }




        
    }
}
