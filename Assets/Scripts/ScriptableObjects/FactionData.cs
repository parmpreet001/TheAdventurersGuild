using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FactionData : ScriptableObject
{
    public string factionName;
    public StringIntDictionary resources;
    public StringIntDictionary attributes;
    public List<Goal> goals;
    public List<Action> actions;
}
