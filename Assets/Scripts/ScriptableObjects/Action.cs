using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{
    public string actionName;
    public TargetType targetType;
    public StringIntDictionary resourceCosts;
    public StringIntDictionary resourceGains;
    public StringIntDictionary targetAttributueChange;
}
