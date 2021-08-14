using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Roster
{
    Dictionary<string, Adventurer> GuildMembers = new Dictionary<string, Adventurer>();
   
    public void AddGuildMember(Adventurer newMember)
    {
        //If there is already a member with the same name, throw an exception
        if(GuildMembers.ContainsKey(newMember.Name))
            throw new Exception("Error: Guild Member with this name already exists");

        //Create new bonds between the new member and all other members, using a default value of 1
        foreach(Adventurer member in GuildMembers.Values)
        {
            member.SetBondLevel(newMember.Name, 1f);
            newMember.SetBondLevel(member.Name, 1f);
        }
        GuildMembers.Add(newMember.Name, newMember);
    }

    /// <summary> Set a bond level between two guild members. </summary>
    public void SetBondLevel(string name1, string name2, float bondLevel)
    {
        if (!GuildMembers.ContainsKey(name1))
            throw new Exception("Error: Member of name " + name1 + " does not exist");
        if (!GuildMembers.ContainsKey(name2))
            throw new Exception("Error: Member of name " + name2 + " does not exist");
        GuildMembers[name1].SetBondLevel(name2, bondLevel);
        GuildMembers[name2].SetBondLevel(name1, bondLevel);
    }

}
