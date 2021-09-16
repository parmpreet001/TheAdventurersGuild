using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Roster roster;
    public Party playerParty;
    public Party enemyParty;
    void Start()
    {
        //A roster keeps track of all the adventurers in the guild
        roster = new Roster();
        //A party consisting of adventurers from the roster
        playerParty = new Party(Party.PartyType.ADVENTURER);
        //A party consisting of enemies that the adventuring party will fighting
        enemyParty = new Party(Party.PartyType.ENEMY);

        //Creating new guild members
        Adventurer tom = new Adventurer("Tom", new EntityStats(10, 10, 20, 10, 10, 10));
        Adventurer eric = new Adventurer("Eric", new EntityStats(15, 15, 15, 15, 15, 15));
        Adventurer bitch = new Adventurer("Bitch", new EntityStats(16, 16, 16, 16, 16, 16));
        Adventurer niko = new Adventurer("Niko", new EntityStats(1, 1, 1, 1, 1, 1));

        //Whenever a new member is added to the guild, their bond with the other members is set to 1.0
        roster.AddGuildMember(tom);
        roster.AddGuildMember(eric);
        roster.AddGuildMember(bitch);
        roster.AddGuildMember(niko);

        //Tom and eric have a bond of 1.2
        roster.SetBondLevel("Tom", "Eric", 1.2f);

        //Party consisting of Tom, Eric, and Bitch
        playerParty.members.Add(roster.GetGuildMember("Tom"));
        playerParty.members.Add(roster.GetGuildMember("Eric"));
        playerParty.members.Add(roster.GetGuildMember("Bitch"));


        Enemy goblin = new Enemy("Boblin", new EntityStats(8, 8, 8, 8, 8, 8));
        
        //When creating enemy parties, you need to add the enemy as a copy, instead of passing over the reference to said enemy
        enemyParty.members.Add(new Enemy(goblin));
        enemyParty.members.Add(new Enemy(goblin));

        //Battle simulation
        Debug.Log("Player Party Stats");
        playerParty.CalculatePartyStats();
        playerParty.PrintStats();

        Debug.Log("Enemy Stats");
        enemyParty.CalculatePartyStats();
        enemyParty.PrintStats();

        Debug.Log("ENemy Party took " + playerParty.TotalAtk + " Damage");
        enemyParty.TakeDamage(playerParty.TotalAtk);
    }
}
