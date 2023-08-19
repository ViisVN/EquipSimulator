using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipItems : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   [Header("ItemData")]
   public ItemsData _itemData, _nullData;
   public string equipname;
   public Image sprite;
   public int Heatlh = 0;
   public int Str = 0;
   public int Def = 0;
   public int Spd = 0;
   public TMP_Text nameText, descrition;
   public GameObject panel;
   public StatusBoardManager _statusboard;
   public InventoryManager _inventoryManager;
   public EquipmentManager _equipmentManager;
   [Header("DoubleClick")]
   private float lastClickTime;
   private Vector2 lastClickPosition;
   public float doubleClickTimeThreshold = 0.5f;
   public float doubleClickDistanceThreshold = 10f;
   public void updateData(ItemsData data)
   {
      _itemData = data;
      equipname = data.name;
      sprite.sprite = data.sprite;
      Heatlh = data.Heatlh;
      Str = data.Str;
      Def = data.Def;
      Spd = data.Spd;
      nameText.text = equipname;
      descrition.text = _itemData.description;
   }
   public void Start()
   {
      _statusboard = GameObject.Find("StatusBoard").GetComponent<StatusBoardManager>();
   }
   public void OnPointerEnter(PointerEventData eventData)
   {
      panel.SetActive(true);
   }
   public void OnPointerExit(PointerEventData eventData)
   {
      panel.SetActive(false);
   }
   public void OnPointerClick(PointerEventData eventData)
   {
      if (IsDoubleClick(eventData)&&_itemData.name!="Null")
      {
         _inventoryManager.addItems(_itemData);
         updateData(_nullData);
         _equipmentManager.updateStatus();

      }
      else
      {
         ItemsData data = eventData.pointerClick.GetComponent<EquipItems>()._itemData;
         _statusboard.OnPointerClick(data);
      }
   }

   private bool IsDoubleClick(PointerEventData eventData)
   {
      float currentTime = Time.time;
      Vector2 currentPosition = eventData.position;

      float timeDifference = currentTime - lastClickTime;
      float positionDifference = Vector2.Distance(currentPosition, lastClickPosition);

      if (timeDifference < doubleClickTimeThreshold && positionDifference < doubleClickDistanceThreshold)
      {
         lastClickTime = 0f; // Reset last click time
         return true;
      }
      else
      {
         lastClickTime = currentTime;
         lastClickPosition = currentPosition;
         return false;
      }
   }

}
