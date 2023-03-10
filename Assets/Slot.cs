using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private int index;
    [SerializeField] private int indexDialog = -1;
    [SerializeField] private DialogScript dialog;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            int[] data = new int[] {this.index, eventData.pointerDrag.GetComponent<DragDrop>().GetWeight()};
            canvas.BroadcastMessage("SetState", data);
            eventData.pointerDrag.GetComponent<DragDrop>().Return();
            gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            if (indexDialog > -1) {
                dialog.GoToDialogIndex(indexDialog);
            }
        }
    }
}
