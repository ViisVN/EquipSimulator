using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemsData> itemsList;
    public GameObject itemsButton;
    public EquipmentManager _equipmentManager;
    
    public void Awake()
    {
        foreach(var item in itemsList)
        {
            GameObject _item =Instantiate(itemsButton,this.transform);
            ItemsManager _itemData = _item.GetComponent<ItemsManager>();
            _itemData._itemsData = item;
        }
    }
    public void addItems(ItemsData go)
    {
        GameObject _item = Instantiate(itemsButton,this.transform);
         ItemsManager _itemData =_item.GetComponent<ItemsManager>();
        _itemData._itemsData = go;
    }
}
