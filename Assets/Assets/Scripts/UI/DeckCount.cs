using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DeckCount : Card
{
    [SerializeField] private TMP_Text deckText;
    [SerializeField] private TMP_Text handText;

    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> hand = new List<Card>();
    [SerializeField] private int totalCards = 52;

    public void InitializeDeck()
    {
        deck.Clear();
        hand.Clear();

        for (int i = 0; i < totalCards; i++)
        {
            var card = Instantiate(Resources.Load<Card>("CardSprites"));
            deck.Add(card);
        }

        UpdateDeckDisplay();
    }

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            return;
        }

        int randomIndex = Random.Range(0, deck.Count);
        Card drawnCard = deck[randomIndex];
        deck.RemoveAt(randomIndex);
        hand.Add(drawnCard);

        UpdateDeckDisplay();
    }

    public void UpdateDeckDisplay()
    {
        deckText.text = $"Deck: {deck.Count}/{totalCards}";
        handText.text = $"Hand: {hand.Count}";
    }

    private void Start()
    {
        InitializeDeck();
        UpdateDeckDisplay();
    }
}
