using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler
{

    [SerializeField] private Canvas canvas;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            canvas.BroadcastMessage("Return");
        }
    }
}
