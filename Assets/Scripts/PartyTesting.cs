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

        party.AddMember(tom);
        party.AddMember(eric);
        party.AddMember(bitch);

        //tom.PrintBondLevels();
        //eric.PrintBondLevels();
        //bitch.PrintBondLevels();

        party.CalculatePartyStats();
        Debug.Log(party.TotalHp);
        Debug.Log(party.TotalAtk);
    }
}
