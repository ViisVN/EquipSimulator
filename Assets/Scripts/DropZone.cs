using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour
{
   void dropZone(PointerEventData data)
   {
     GameObject draggedObject = data.pointerDrag;
     if (draggedObject != null)
     {

        Debug.Log(gameObject.name+"--"+draggedObject.name);
     }
   }
}
