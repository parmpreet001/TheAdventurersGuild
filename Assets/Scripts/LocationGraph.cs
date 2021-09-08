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
    /// <param name="parentLocationName">Name of the first location</param>
    /// <param name="secondLocation">Name of the second location</param>
    /// <param name="distance">Distance between the to nodes</param>
    public void AddLocationLink(Location firstLocation, Location secondLocation, int distance)
    {
        if(!Search(firstLocation))
            locations.Add(firstLocation);
        if(!Search(secondLocation))
            locations.Add(secondLocation);

        if(firstLocation.Search(secondLocation))
            throw new Exception("Exception: The connection that you are trying to add already exists");

        firstLocation.connectedLocations.Add(secondLocation.locationName);
        firstLocation.distances.Add(secondLocation.locationName, distance);
        secondLocation.connectedLocations.Add(firstLocation.locationName);
        secondLocation.distances.Add(firstLocation.locationName, distance);
    }

    /// <summary> Returns true if a location exists in the tree </summary>
    public bool Search(string name)
    {
        foreach(Location loc in locations)
        {
            if(loc.locationName.Equals(name))
                return true;
        }
        return false;
    }

    public bool Search(Location location)
    {
        foreach(Location loc in locations)
        {
            if (loc.locationName.Equals(location.locationName))
                return true;
        }
        return false;
    }

    /// <summary> Takes the name of a location and returns the respective location object </summary>
    public Location GetLocation(string name)
    {
        foreach (Location loc in locations)
        {
            if (loc.locationName.Equals(name))
                return loc;
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

        AddLocationLink(locationA, locationC, 3);
        
        AddLocationLink(locationA, locationF, 2);
        AddLocationLink(locationC, locationD, 4);
        AddLocationLink(locationC, locationE, 1);
        AddLocationLink(locationC, locationF, 2);
        AddLocationLink(locationF, locationE, 3);
        AddLocationLink(locationF, locationB, 6);
        AddLocationLink(locationF, locationG, 5);
        AddLocationLink(locationE, locationB, 2);
        AddLocationLink(locationD, locationB, 1);
        AddLocationLink(locationG, locationB, 2);
        

        Stack<Location> path = FindPath(locationA, locationB);

        Debug.Log("Path from location A to location B");
        while (path.Count > 0)
        {
            Location temp = path.Pop();
            Debug.Log(temp.locationName + ", Danger Sum: " + temp.dangerSum);
        }
        
    }
}
