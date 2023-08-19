using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class EquipmentManager : MonoBehaviour, IDropHandler
{
    [Header("EquipManager")]
    public Action<ItemsData> sendItems;
    public EquipItems head, body, leg;
    public TMP_Text Hp, Str, Def, Spd, Set;
    public BonusSetList bonusSetList;
    public SetBonus _setBonus;
    public SetBonus _nullSet;
    public ItemsData _itemData;
    public bool isDrop = false;
    public CharacterManager _charactermanager;
    [Header("Inventory")]
    [SerializeField] InventoryManager _inventoryManager;
    public void OnDrop(PointerEventData data)
    {
        _itemData = data.pointerDrag.GetComponent<ItemsManager>()._itemsData;

        switch (_itemData.Type)
        {
            case ItemsData.ItemType.head:
                if (head._itemData.name != "Null")
                {
                    _inventoryManager.addItems(head._itemData);

                }
                head.updateData(_itemData);
                                    isDrop = true;
                break;
            case ItemsData.ItemType.body:
                if (body._itemData.name != "Null")
                {
                    _inventoryManager.addItems(body._itemData);

                }
                body.updateData(_itemData);
                                          isDrop = true;
                break;
            case ItemsData.ItemType.leg:
                if (leg._itemData.name != "Null")
                {
                    _inventoryManager.addItems(leg._itemData);

                }
                leg.updateData(_itemData);
                                          isDrop = true;
                break;
        }

        updateStatus();

    }
    public void updateStatus()
    {
        SetName(Set, item => item._itemData.set);
        equipStatus(Hp, item => item._itemData.Heatlh, set => set.Heatlh);
        equipStatus(Str, item => item._itemData.Str, set => set.Str);
        equipStatus(Def, item => item._itemData.Def, set => set.Def);
        equipStatus(Spd, item => item._itemData.Spd, set => set.Spd);
        _charactermanager.Str = _charactermanager._charData.Str+increaseStatus(item=>item._itemData.Str,set=>set.Str);
    }
    public void equipStatus(TMP_Text text, Func<EquipItems, int> attributeFunc, Func<SetBonus, int> setBonus)
    {
        //Tra ve text gia tri cua tong Set do
        int setValue = setBonus(_setBonus);
        text.text = text.gameObject.name + ": " + (increaseStatus(attributeFunc, setBonus)) + "(+ " + setValue + ")";
    }

    public int increaseStatus(Func<EquipItems, int> attributeFunc, Func<SetBonus, int> setBonusFunc)
    {
        int H_value = attributeFunc(head);
        int B_value = attributeFunc(body);
        int L_value = attributeFunc(leg);

        int setValue = setBonusFunc(_setBonus);

        return H_value + B_value + L_value + setValue;
    }
    public void SetName(TMP_Text text, Func<EquipItems, IComparable> pieceType)
    {
        //Loai do
        IComparable H_value = pieceType(head);
        IComparable B_value = pieceType(body);
        IComparable L_value = pieceType(leg);
        //So sanh ba manh
        if (H_value.Equals(B_value) && H_value.Equals(L_value))
        {
            //Tim kiem set 
            foreach (var set in bonusSetList.setBonusList)
            {
                if ((int)set.set == Convert.ToInt32(H_value))
                {
                    text.text = text.gameObject.name + ": " + set.setName;
                    _setBonus = set;
                    return;
                }
            }
        }
        else
        {
            text.text = text.gameObject.name + ": None";
            _setBonus = _nullSet;
        }
    }
}
