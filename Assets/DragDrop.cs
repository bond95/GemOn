using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Linq;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject creature;

    [SerializeField] private TMP_Text text;
    [SerializeField] private int weight;
    [SerializeField] private int count;
    [SerializeField] private AudioSource audioSource;


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

    private void updateCount() {
        this.text.text = "x" + this.count.ToString();
    }

    private void checkRemainig() {
        var creature_state = this.creature.GetComponent<CreatureGenerator>();
        var remaining = Enumerable.Select(creature_state.state , (item, i) => new { Item = item, Index = i })
                .Where(x => !Enumerable.Contains(creature_state.finish_state[x.Index].states, x.Item) && Enumerable.Contains(creature_state.finish_state[x.Index].states, this.weight));
        var left_to_set = Enumerable.Count(remaining);
        if (left_to_set > this.count) {
            canvas.BroadcastMessage("Finish", false);
        }
    }

    void Start()
    {
        updateCount();
    }

    void Update()
    {
        if (this.count == 0 || this.returning == false) {
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
        if (this.count == 0) { return; }
        this.dragged = true;
        this.initialPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        if (audioSource) {
            audioSource.Play();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.count == 0) { return; }

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void Return() {
        if (this.count > 0) {
            Math.Max(this.count--, 0);
            updateCount();
            checkRemainig();
        }
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
        if (this.count == 0) { return; }

        this.returning = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

    }


}