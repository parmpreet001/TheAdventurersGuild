using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionSystem : MonoBehaviour
{
    [SerializeField]
    public List<FactionData> factions;

    private void Awake()
    {
        for(int i = 0; i < factions.Count; i++)
        {
            factions[i] = ScriptableObject.Instantiate(factions[i]);
        }

        foreach(FactionData faction in factions)
        {
            foreach(FactionData otherFaction in factions)
            {
                if(!faction.factionName.Equals(otherFaction.factionName))
                {
                    FactionData temp = ScriptableObject.CreateInstance<FactionData>();
                    temp.factionName = otherFaction.factionName;
                    faction.factionAwareness.Add(temp);

                    Debug.Log("Added " + temp.factionName + " to " + faction.factionName);
                }
            }
        }

        foreach(FactionData faction in factions)
        {
            Debug.Log(faction.factionAwareness.Count);
        }
    }
}
