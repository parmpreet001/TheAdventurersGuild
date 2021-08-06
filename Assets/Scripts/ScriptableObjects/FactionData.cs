using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FactionData : ScriptableObject
{
    public string factionName;
    public StringIntDictionary resources = new StringIntDictionary(true, false, globalMin: 0);
    public StringIntDictionary attributes = new StringIntDictionary(true, true, globalMin: 0, globalMax: 100);
    public StringIntDictionary attributeOpinions = new StringIntDictionary(true, true, globalMin: -1, globalMax: 10);
    public List<Goal> goals;
    public List<Action> actions;
    public List<FactionData> factionAwareness;
}
