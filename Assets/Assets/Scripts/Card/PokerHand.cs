using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerHands
{
    public enum Hand
    {
        RoyalFlush,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }

    public static int GetDamage(Hand hand)
    {
        switch (hand)
        {
            case Hand.RoyalFlush:
                return 100;
            case Hand.StraightFlush:
                return 80;
            case Hand.FourOfAKind:
                return 70;
            case Hand.FullHouse:
                return 50;
            case Hand.Flush:
                return 40;
            case Hand.Straight:
                return 30;
            case Hand.ThreeOfAKind:
                return 20;
            case Hand.TwoPair:
                return 10;
            case Hand.OnePair:
                return 5;
            case Hand.HighCard:
            default:
                return 0;
        }
    }
}