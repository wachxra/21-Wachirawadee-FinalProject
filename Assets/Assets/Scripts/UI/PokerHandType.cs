using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokerHandType : PokerHand
{
    [SerializeField] private Text handTextUI;

    public PokerHandType() : base("Unknown", 0) { }

    public PokerHandType(string handName, int strength) : base(handName, strength) { }

    public override void DisplayHandInfo(string handName, int strength)
    {
        if (handTextUI != null)
        {
            handTextUI.text = $"{handName}: Strength {strength}";
        }
        else
        {
            Debug.LogWarning("No Damage!");
        }
    }

    public PokerHand EvaluateHand(List<PokerHand.Rank> ranks, List<PokerHand.Suit> suits)
    {
        if (IsRoyalFlush(ranks, suits))
            return new RoyalFlush();
        if (IsStraightFlush(ranks, suits))
            return new StraightFlush();
        if (IsFourOfAKind(ranks))
            return new FourOfAKind();
        if (IsFullHouse(ranks))
            return new FullHouse();
        if (IsFlush(suits))
            return new Flush();
        if (IsStraight(ranks))
            return new Straight();
        if (IsThreeOfAKind(ranks))
            return new ThreeOfAKind();
        if (IsTwoPair(ranks))
            return new TwoPair();
        if (IsOnePair(ranks))
            return new OnePair();

        return new HighCard();
    }

    private bool IsRoyalFlush(List<PokerHand.Rank> ranks, List<PokerHand.Suit> suits)
    {
        return IsFlush(suits) && ranks.Contains(PokerHand.Rank.Ace) && ranks.Contains(PokerHand.Rank.King)
            && ranks.Contains(PokerHand.Rank.Queen) && ranks.Contains(PokerHand.Rank.Jack)
            && ranks.Contains(PokerHand.Rank.Ten);
    }

    private bool IsStraightFlush(List<PokerHand.Rank> ranks, List<PokerHand.Suit> suits)
    {
        return IsFlush(suits) && IsStraight(ranks);
    }

    private bool IsFourOfAKind(List<PokerHand.Rank> ranks)
    {
        return HasNOfAKind(ranks, 4);
    }

    private bool IsFullHouse(List<PokerHand.Rank> ranks)
    {
        return HasNOfAKind(ranks, 3) && HasNOfAKind(ranks, 2);
    }

    private bool IsFlush(List<PokerHand.Suit> suits)
    {
        return suits.TrueForAll(s => s == suits[0]); // All suits must be the same
    }

    private bool IsStraight(List<PokerHand.Rank> ranks)
    {
        ranks.Sort();
        for (int i = 1; i < ranks.Count; i++)
        {
            if (ranks[i] != ranks[i - 1] + 1)
                return false;
        }
        return true;
    }

    private bool IsThreeOfAKind(List<PokerHand.Rank> ranks)
    {
        return HasNOfAKind(ranks, 3);
    }

    private bool IsTwoPair(List<PokerHand.Rank> ranks)
    {
        int pairCount = 0;
        foreach (PokerHand.Rank rank in System.Enum.GetValues(typeof(PokerHand.Rank)))
        {
            if (ranks.FindAll(r => r == rank).Count == 2)
                pairCount++;
        }
        return pairCount == 2;
    }

    private bool IsOnePair(List<PokerHand.Rank> ranks)
    {
        return HasNOfAKind(ranks, 2);
    }

    private bool HasNOfAKind(List<PokerHand.Rank> ranks, int n)
    {
        foreach (PokerHand.Rank rank in System.Enum.GetValues(typeof(PokerHand.Rank)))
        {
            if (ranks.FindAll(r => r == rank).Count == n)
                return true;
        }
        return false;
    }

    void Start()
    {
        List<PokerHand.Rank> ranks = new List<PokerHand.Rank>
        {
            PokerHand.Rank.Ace, PokerHand.Rank.King, PokerHand.Rank.Queen, PokerHand.Rank.Jack, PokerHand.Rank.Ten
        };
        List<PokerHand.Suit> suits = new List<PokerHand.Suit>
        {
            PokerHand.Suit.Hearts, PokerHand.Suit.Hearts, PokerHand.Suit.Hearts, PokerHand.Suit.Hearts, PokerHand.Suit.Hearts
        };

        PokerHand evaluatedHand = EvaluateHand(ranks, suits);
        DisplayHandInfo(evaluatedHand.HandName, evaluatedHand.Strength);
    }
}