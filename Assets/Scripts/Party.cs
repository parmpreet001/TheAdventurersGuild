using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party
{
    public enum PartyType
    {
        ENEMY, ADVENTURER
    }

    public List<Entity> members = new List<Entity>();
    public int TotalHp { get; private set; }
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
                    if (!otherMember.Name.Equals(member.Name))
                        otherMembers.Add(otherMember.Name);
                }
                float memberAvgBond = member.GetAvgBond(otherMembers);
                Debug.Log(member.Name + "'s average bond is " + memberAvgBond);
                TotalHp += member.Stats.hp;
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
                TotalHp += member.Stats.hp;
                TotalAtk += member.Stats.atk;
                TotalTrt += member.Stats.trt;
                TotalCmp += member.Stats.cmp;
                TotalIntl += member.Stats.intl;
                TotalWis += member.Stats.wis;
            }
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
        TotalHp = 0;
        TotalAtk = TotalCmp = TotalIntl = TotalTrt = TotalWis = 0f;
    }
}
