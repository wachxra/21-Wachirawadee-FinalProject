using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.EventSystems;

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

    // เพิ่มตัวแปรสำหรับการจำกัดจำนวนการ์ดที่เลือก
    private const int maxSelectableCards = 5;
    private int selectedCardCount = 0;  // นับจำนวนการ์ดที่เลือก

    void Start()
    {
        for (int i = 0; i < cardsToSpawn; i++)
        {
            Instantiate(slotPrefab, transform);
        }

        rect = GetComponent<RectTransform>();
        cards = GetComponentsInChildren<Card>().ToList();

        foreach (Card card in cards)
        {
            card.PointerEnterEvent.AddListener(CardPointerEnter);
            card.PointerExitEvent.AddListener(CardPointerExit);
            card.BeginDragEvent.AddListener(BeginDrag);
            card.EndDragEvent.AddListener(EndDrag);
        }
    }

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

        Debug.Log($"Selected cards count: {selectedCardCount}");

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedCardCount >= maxSelectableCards && hoveredCard != null && !hoveredCard.selected)
            {
                Debug.LogWarning("You can choose only 5 cards!");
                return;
            }

            if (hoveredCard != null && !hoveredCard.selected)
            {
                hoveredCard.Select();
                selectedCardCount++;
            }
            else if (hoveredCard != null && hoveredCard.selected)
            {
                hoveredCard.Deselect();
                selectedCardCount--;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (Card card in cards)
            {
                if (card.selected)
                {
                    card.Deselect();
                    selectedCardCount--;
                }
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
