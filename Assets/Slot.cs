using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private int index;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<DragDrop>().Return();
            int[] data = new int[] {this.index, eventData.pointerDrag.GetComponent<DragDrop>().GetWeight()};
            canvas.BroadcastMessage("SetState", data);
            gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        }
    }
}
