using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationGraph : MonoBehaviour
{
    [SerializeField]
    private List<Location> locations = new List<Location>();

    public void AddLocation(Location loc)
    {
        locations.Add(loc);
    }

    /// <summary>Creates an undirected link between two locations</summary>
    /// <param name="parentLocationName">Name of the parent location</param>
    /// <param name="childLocation">New Location to be added to parrent</param>
    public void AddLocationLink(string parentLocationName, Location childLocation, int edgeWeight)
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

                //Sets edge weight between the two locations
                loc.distances.Add(childLocation.locationName,edgeWeight);
                childLocation.distances.Add(parentLocationName, edgeWeight);

                return;
            }
        }
        throw new Exception("Exception: Cannot find location with specified name");
    }

    /// <summary> Returns true if a location exists in the tree </summary>
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

    /// <summary> Takes the name of a location and returns the respective location object </summary>
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

    public Stack<Location> FindPath(Location startLocation, Location targetLocation)
    {
        Stack<Location> path = new Stack<Location>();

        foreach(Location loc in locations)
        {
            loc.distance = 100;
            loc.visited = false;
            loc.prev = null;
            loc.dangerSum = loc.DangerLevel;
        }

        startLocation.distance = 0;

        while(!targetLocation.visited)
        {
            Location loc = GetNearestUnexploredLocation();
            loc.visited = true;
            foreach(string neighbor in loc.connectedLocations)
            {
                if(loc.distance + loc.distances[neighbor] < GetLocation(neighbor).distance)
                {
                    GetLocation(neighbor).distance = loc.distance + loc.distances[neighbor];
                    GetLocation(neighbor).prev = loc;
                    GetLocation(neighbor).dangerSum = loc.dangerSum + GetLocation(neighbor).DangerLevel;
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

    /// <summary> Used for path findning. Returns the unexplored distance with the lowest distance value </summary>
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

        locations.Add(locationA);

        AddLocationLink("location A", locationC, 3);
        AddLocationLink("location A", locationF, 2);
        AddLocationLink("location C", locationD, 4);
        AddLocationLink("location C", locationE, 1);
        AddLocationLink("location C", locationF, 2);
        AddLocationLink("location F", locationE, 3);
        AddLocationLink("location F", locationB, 6);
        AddLocationLink("location F", locationG, 5);
        AddLocationLink("location E", locationB, 2);
        AddLocationLink("location D", locationB, 1);
        AddLocationLink("location G", locationB, 2);

        Stack<Location> path = FindPath(locationA, locationB);

        Debug.Log("Path from location A to location B");
        while (path.Count > 0)
        {
            Location temp = path.Pop();
            Debug.Log(temp.locationName + ", Danger Sum: " + temp.dangerSum);
        }      
    }
}
