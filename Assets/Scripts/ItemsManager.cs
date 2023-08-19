using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemsManager : MonoBehaviour
{
    [Header("GetButtonInfor")]
    public static System.Action<ItemsData> sendStatus;
    public ItemsData _itemsData;
    public GameObject _itemObject;
    public string _itemsName;
    public string _itemsDescription;
    public int _itemsHealthMax;
    public int _itemsStr;
    public int _itemsDef;
    public int _itemsSpd;
    public int _itemsType;
    public Image _itemsImage;
    public Button _itemsButton;
    public EventTrigger _eventTrigger;
    private GridLayoutGroup gridGroup;
    public StatusBoardManager statusboard;
    public EquipmentManager _equipManager;
    // Start is called before the first frame update
    void Start()
    {   _equipManager = GameObject.Find("ItemsBoard").GetComponent<EquipmentManager>();
        statusboard = GameObject.Find("StatusBoard").GetComponent<StatusBoardManager>();
        _itemsButton = GetComponent<Button>();
        _itemsImage = GetComponent<Image>();
        _itemObject = this.gameObject;
        _itemsName = _itemsData.name;
        _itemsDescription = _itemsData.description;
        _itemsHealthMax = _itemsData.Heatlh;
        _itemsStr = _itemsData.Str;
        _itemsDef = _itemsData.Def;
        _itemsSpd = _itemsData.Spd;
        _itemsType = (int)_itemsData.Type;
        _itemsImage.sprite = _itemsData.sprite;
        this.gameObject.name = _itemsName;
        gridGroup = GetComponentInParent<GridLayoutGroup>();
        _eventTrigger = GetComponent<EventTrigger>();
        EventTriggerManager();

    }
    void Click(PointerEventData data)
    {
        ItemsData _data = data.pointerClick.GetComponent<ItemsManager>()._itemsData;
        statusboard.OnPointerClick(_data);
    }
    void Drag(PointerEventData data)
    {
        gridGroup.enabled = false;
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        Vector2 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        transform.position = rayPoint;
    }
    void EndDrag(PointerEventData data)
    {
        gridGroup.enabled = true;
        if( _equipManager.isDrop)
        {
                       Destroy(data.pointerDrag);
           _equipManager.isDrop = false;

        } 
    }
    void EventTriggerManager()
    {
        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        EventTrigger.Entry entry_click = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_click.eventID = EventTriggerType.PointerClick;

        //Add Listener
        entry_Drag.callback.AddListener((data) => { Drag((PointerEventData)data); });
        entry_EndDrag.callback.AddListener((data) => { EndDrag((PointerEventData)data); });
        entry_click.callback.AddListener((data) => {Click((PointerEventData)data);});

        _eventTrigger.triggers.Add(entry_Drag);
        _eventTrigger.triggers.Add(entry_EndDrag);
        _eventTrigger.triggers.Add(entry_click);
    }

}
