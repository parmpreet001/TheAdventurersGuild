using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Roster
{
    private Dictionary<string, Adventurer> guildMembers = new Dictionary<string, Adventurer>();
   
    /// <summary> Add a new guild member and set their bond with other guild members to 1 </summary>
    public void AddGuildMember(Adventurer newMember)
    {
        //If there is already a member with the same name, throw an exception
        if(guildMembers.ContainsKey(newMember.entityName))
            throw new Exception("Error: Guild Member with this name already exists");

        //Create new bonds between the new member and all other members, using a default value of 1
        foreach(Adventurer member in guildMembers.Values)
        {
            member.SetBondLevel(newMember.entityName, 1f);
            newMember.SetBondLevel(member.entityName, 1f);
        }
        guildMembers.Add(newMember.entityName, newMember);
    }

    /// <summary> Set a bond level between two guild members. </summary>
    public void SetBondLevel(string name1, string name2, float bondLevel)
    {
        if (!guildMembers.ContainsKey(name1))
            throw new Exception("Error: Member of name " + name1 + " does not exist");
        if (!guildMembers.ContainsKey(name2))
            throw new Exception("Error: Member of name " + name2 + " does not exist");
        guildMembers[name1].SetBondLevel(name2, bondLevel);
        guildMembers[name2].SetBondLevel(name1, bondLevel);
    }

}
