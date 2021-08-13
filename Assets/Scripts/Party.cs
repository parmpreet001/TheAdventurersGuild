using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    private List<Entity> members = new List<Entity>();
    public int TotalHp { get; private set; }
    public int TotalAtk { get; private set; }
    public int TotalTrt { get; private set; }
    public int TotalCmp { get; private set; }
    public int TotalIntl { get; private set; }
    public int TotalWis { get; private set; }
}
