using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public string Name { get; protected set; }
    public EntityStats Stats { get; protected set; }
    public int Level { get; protected set; }
}