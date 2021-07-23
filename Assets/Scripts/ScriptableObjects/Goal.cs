using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Goal : ScriptableObject
{
    public string goalName;
    public string attribute;
    public GoalType goalType;
    public TargetType targetType;
}
