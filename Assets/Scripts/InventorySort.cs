using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySort : MonoBehaviour
{
    public Transform parent;
    public Button SortByName,SortByType,SortBySTR;

    public void Start()
    {
        parent = GetComponentInParent<Transform>();
        SortByName.onClick.AddListener(()=>Sort(item => item._itemsName));
        SortByName.GetComponentInChildren<TMPro.TMP_Text>().text = "SortByName";
        SortBySTR.onClick.AddListener(()=>Sort(item => item._itemsStr));
        SortBySTR.GetComponentInChildren<TMPro.TMP_Text>().text = "SortBySTR";
        SortByType.onClick.AddListener(()=>Sort(item => item._itemsType));
        SortByType.GetComponentInChildren<TMPro.TMP_Text>().text = "SortByType";
    }
    public void Sort(Func<ItemsManager,IComparable> sortingCriteria)
    {
        Transform[] childrenTransform = new Transform[parent.childCount];
        for (int i = 0; i < parent.childCount; i++)
        {
            childrenTransform[i] = parent.GetChild(i);

        }
        Array.Sort(childrenTransform, (a, b) =>
        {
            IComparable valueA = sortingCriteria(a.GetComponent<ItemsManager>());
            IComparable valueB = sortingCriteria(b.GetComponent<ItemsManager>());
            return valueA.CompareTo(valueB);
        });
        for (int i = 0; i < parent.childCount; i++)
        {
            childrenTransform[i].SetSiblingIndex(i);
        }

    }
}
