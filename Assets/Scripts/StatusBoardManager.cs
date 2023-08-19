using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StatusBoardManager : MonoBehaviour
{
    public TMP_Text statusname,health,str,spd,def, description;
    public Image image;
    public void OnPointerClick(ItemsData itemsData)
    {
        if(itemsData ==null)
        {
            return;
        }
        statusname.text = itemsData.name;
        health.text = itemsData.Heatlh.ToString();
        str.text = itemsData.Str.ToString();
        spd.text = itemsData.Spd.ToString();
        def.text = itemsData.Def.ToString();
        description.text = itemsData.description.ToString();
        image.sprite = itemsData.sprite;
    }   
    
}
