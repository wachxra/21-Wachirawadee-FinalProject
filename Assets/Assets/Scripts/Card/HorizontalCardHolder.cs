using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class HorizontalCardHolder : MonoBehaviour
{
    [SerializeField] private Card selectedCard;
    [SerializeReference] private Card hoveredCard;

    [SerializeField] private GameObject slotPrefab;
    private RectTransform rect;

    [Header("Spawn Settings")]
    [SerializeField] private int cardsToSpawn = 7;
    public List<Card> cards;

    bool isCrossing = false;
    [SerializeField] private bool tweenCardReturn = true;

    void Start()
    {
        for (int i = 0; i < cardsToSpawn; i++)
        {
            Instantiate(slotPrefab, transform);
        }

        rect = GetComponent<RectTransform>();
        cards = GetComponentsInChildren<Card>().ToList();

        int cardCount = 0;

        foreach (Card card in cards)
        {
            card.PointerEnterEvent.AddListener(CardPointerEnter);
            card.PointerExitEvent.AddListener(CardPointerExit);
            card.BeginDragEvent.AddListener(BeginDrag);
            card.EndDragEvent.AddListener(EndDrag);
            card.name = cardCount.ToString();
            cardCount++;
        }
    }

    public bool isSelectedFull = false;
    public int cardCount = 0;

    private void BeginDrag(Card card)
    {
        selectedCard = card;
    }

    void EndDrag(Card card)
    {
        if (selectedCard == null || selectedCard.transform == null) return;

        selectedCard.transform.DOLocalMove(
            selectedCard.selected ? new Vector3(0, selectedCard.selectionOffset, 0) : Vector3.zero,
            tweenCardReturn ? .15f : 0
        ).SetEase(Ease.OutBack);

        // Refresh layout
        rect.sizeDelta += Vector2.right;
        rect.sizeDelta -= Vector2.right;

        selectedCard = null;
    }

    void CardPointerEnter(Card card)
    {
        hoveredCard = card;
    }

    void CardPointerExit(Card card)
    {
        hoveredCard = null;
    }

    void Update()
    {
        cards.RemoveAll(c => c == null);

        Debug.Log($"Selected cards count: {cards.Count(c => c.selected)}");

        // จำกัดการ์ดที่เลือกได้ไม่เกิน 5 ใบ หากผู้ใช้กดคลิกซ้าย
        if (Input.GetMouseButtonDown(0))
        {
            if (cards.Count(c => c.selected) >= 5 && hoveredCard != null && !hoveredCard.selected)
            {
                Debug.LogWarning("ไม่สามารถเลือกการ์ดเกิน 5 ใบ!");
                return;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (Card card in cards)
            {
                card.Deselect();
            }
        }

        if (selectedCard == null)
            return;

        if (isCrossing)
            return;

        for (int i = 0; i < cards.Count; i++)
        {
            if (selectedCard.transform.position.x > cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() < cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }

            if (selectedCard.transform.position.x < cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() > cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }
        }
    }

    void Swap(int index)
    {
        isCrossing = true;

        Transform focusedParent = selectedCard.transform.parent;
        Transform crossedParent = cards[index].transform.parent;

        cards[index].transform.SetParent(focusedParent);
        cards[index].transform.localPosition = cards[index].selected ? new Vector3(0, cards[index].selectionOffset, 0) : Vector3.zero;
        selectedCard.transform.SetParent(crossedParent);

        isCrossing = false;

        // Check if cardVisual is not null before calling UpdateIndex
        if (cards[index].cardVisual != null && selectedCard.cardVisual != null)
        {
            bool swapIsRight = cards[index].ParentIndex() > selectedCard.ParentIndex();
            cards[index].cardVisual.Swap(swapIsRight ? -1 : 1);
        }
        else
        {
            Debug.LogWarning("cardVisual is null on one or both cards.");
        }
    }
}