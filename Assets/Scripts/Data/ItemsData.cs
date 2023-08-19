using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsData", menuName = "SoubiSimulator/ItemsData", order = 0)]
public class ItemsData : ScriptableObject 
{
   public new string name;
   public string description;
   public Sprite sprite;
   public int Heatlh;
   public int Str;
   public int Def;
   public int Spd;
   
   public enum ItemType
   {
     head = 0,
     body = 1,
     leg = 2,
     potion = 3,
     other = 4
   }
   public ItemType Type;
   public enum SetType
   {
    brozen = 0,
    silver = 1,
    gold = 2,
    other = 3 
   }
   public SetType set;
}

