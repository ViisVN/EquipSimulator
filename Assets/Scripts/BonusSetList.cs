using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSetList : MonoBehaviour
{
    public List<SetBonus> setBonusList;
    public Dictionary<ItemsData.SetType, SetBonus> setBonuses = new Dictionary<ItemsData.SetType, SetBonus>();
    public void Start()
    {

    }
}
