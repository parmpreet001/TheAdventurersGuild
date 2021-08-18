using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyTesting : MonoBehaviour
{
    private void Start()
    {
        Party party = new Party(Party.PartyType.ADVENTURER);
        Roster roster = new Roster();

        Adventurer tom = new Adventurer("Tom", new EntityStats(10, 10, 10, 10, 10, 10));
        Adventurer eric = new Adventurer("Eric", new EntityStats(15, 15, 15, 15, 15, 15));
        Adventurer bitch = new Adventurer("Bitch", new EntityStats(16, 16, 16, 16, 16, 16));

        roster.AddGuildMember(tom);
        roster.AddGuildMember(eric);
        roster.AddGuildMember(bitch);

        roster.SetBondLevel("Tom", "Eric", 1.2f);

        party.members.Add(tom);
        party.members.Add(eric);
        party.members.Add(bitch);

        //tom.PrintBondLevels();
        //eric.PrintBondLevels();
        //bitch.PrintBondLevels();

        party.CalculatePartyStats();
        party.PrintStats();

        Debug.Log("Removing tom from the party and re-calculating stats");
        //party.members.Remove(tom);

        party.CalculatePartyStats();
        party.PrintStats();

        Debug.Log("Party took 10 damage");
        party.TakeDamage(10);
        party.CalculatePartyStats();
        party.PrintStats();
    }
}
