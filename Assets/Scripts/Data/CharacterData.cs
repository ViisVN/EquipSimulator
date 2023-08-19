using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "SoubiSimulator/CharacterData", order = 0)]
public class CharacterData : ScriptableObject 
{
    public new string name;
    public int Health,Str,Spd,Def;
}