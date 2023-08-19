using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SetBonus", menuName = "SoubiSimulator/SetBonus", order = 0)]
public class SetBonus : ScriptableObject
{
    public string setName;
    public int Heatlh;
    public int Str;
    public int Def;
    public int Spd;
    public enum SetType
    {
        brozen = 0,
        silver = 1,
        gold = 2,
        other = 3
    }
    public SetType set;
}

