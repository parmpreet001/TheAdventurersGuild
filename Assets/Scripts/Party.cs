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
                List<string> otherMembers = new List<string>();
                foreach(Adventurer otherMember in members)
                {
                    if (!otherMember.entityName.Equals(member.entityName))
                        otherMembers.Add(otherMember.entityName);
                }
                float memberAvgBond = member.GetAvgBond(otherMembers);
                Debug.Log(member.entityName + "'s average bond is " + memberAvgBond);
                TotalHp += member.stats.hp;
                TotalAtk += member.GetAtk(memberAvgBond);
                TotalTrt += member.GetTrt(memberAvgBond);
                TotalCmp += member.GetCmp(memberAvgBond);
                TotalIntl += member.GetIntl(memberAvgBond);
                TotalWis += member.GetWis(memberAvgBond);
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
        foreach(Entity member in members)
        {
            member.stats.hp -= (float)Math.Round((damage * (member.stats.trt / TotalTrt)),1);
            Debug.Log(member.entityName + " took " + (float)Math.Round((damage * (member.stats.trt / TotalTrt)), 1) + " damage");
        }
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
