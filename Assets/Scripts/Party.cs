using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Party
{
    public enum PartyType
    {
        ENEMY, ADVENTURER
    }

    public List<Entity> members = new List<Entity>();
    public float TotalHp { get; private set; }
    public float TotalAtk { get; private set; }
    public float TotalTrt { get; private set; }
    public float TotalCmp { get; private set; }
    public float TotalIntl { get; private set; }
    public float TotalWis { get; private set; }
    private PartyType partyType;

    public Party(PartyType partyType)
    {
        this.partyType = partyType;
    }

    public void CalculatePartyStats()
    {
        ResetStats();
        if(partyType == PartyType.ADVENTURER)
        { 
            foreach(Adventurer member in members)
            { 
                if(!member.isDead)
                {
                    List<string> otherMembers = new List<string>();
                    //Add every other alive party member that isn't the currently selected member
                    foreach(Adventurer otherMember in members)
                    {
                        if (!otherMember.entityName.Equals(member.entityName) && !otherMember.isDead)
                            otherMembers.Add(otherMember.entityName);
                    }
                    member.SetAvgBond(otherMembers);
                    Debug.Log(member.entityName + "'s average bond is " + member.avgBond);
                    TotalHp += member.stats.hp;
                    TotalAtk += member.CalculateAtk();
                    TotalTrt += member.CalculateTrt();
                    TotalCmp += member.CalculateCmp();
                    TotalIntl += member.CalculateIntl();
                    TotalWis += member.CalculateWisdom();
                }
            }
        }
        else
        {
            foreach(Enemy member in members)
            {
                TotalHp += member.stats.hp;
                TotalAtk += member.stats.atk;
                TotalTrt += member.stats.trt;
                TotalCmp += member.stats.cmp;
                TotalIntl += member.stats.intl;
                TotalWis += member.stats.wis;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(partyType == PartyType.ADVENTURER)
        {
            foreach(Adventurer member in members)
            {
                member.stats.hp -= (float)Math.Round((damage * (member.CalculateTrt() / TotalTrt)),1);
                Debug.Log(member.entityName + " took " + (float)Math.Round((damage * (member.CalculateTrt() / TotalTrt)), 1) + " damage");
                if (member.stats.hp <= 0)
                {
                    member.isDead = true;
                    Debug.Log(member.entityName + " fucking died");
                }
            }
        }
        else
        {
            //TODO Damage calculation for enemy
        }
    }

    /// <summary> Returns true if this party's cmp is less than the given party's threat </summary>
    public bool PartyFlees(Party party)
    {
        return TotalCmp < party.TotalTrt;
    }

    public void PrintStats()
    {
        Debug.Log("Total HP: " + TotalHp);
        Debug.Log("Total Atk: " + TotalAtk);
        Debug.Log("Total Trt: " + TotalTrt);
        Debug.Log("Total Cmp: " + TotalCmp);
        Debug.Log("Total Intl: " + TotalIntl);
        Debug.Log("Total Wis: " + TotalWis);
    }

    private void ResetStats()
    {
        TotalHp = TotalAtk = TotalCmp = TotalIntl = TotalTrt = TotalWis = 0f;
    }
}
