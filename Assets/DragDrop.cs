using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private int weight;

    private RectTransform rectTransform;
    private UnityEngine.Vector2 initialPosition;
    private CanvasGroup canvasGroup;
    private float speed = 5f;
    private bool returning = false;
    private bool dragged = false;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (this.returning == false) {
            return;
        }
        Vector2 position = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
        if (this.initialPosition != position) {
            rectTransform.anchoredPosition = UnityEngine.Vector2.MoveTowards(rectTransform.anchoredPosition, this.initialPosition, speed);
        } else if (this.initialPosition == position) {
            this.returning = false;
            this.dragged = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.dragged = true;
        this.initialPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void Return() {
        if (this.dragged) {
            rectTransform.anchoredPosition = this.initialPosition;
            this.dragged = false;
        }
    }

    public int GetWeight() {
        return this.weight;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.returning = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

    }


}