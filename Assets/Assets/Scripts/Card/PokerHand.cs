using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerHand : Card
{
    public enum Rank
    {
        Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5,
        Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11, Queen = 12, King = 13
    }

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public Rank GetRandomRank()
    {
        return (Rank)UnityEngine.Random.Range(1, 14);
    }

    public Suit GetRandomSuit()
    {
        return (Suit)UnityEngine.Random.Range(0, 4);
    }

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
            case Hand.RoyalFlush: return 100;
            case Hand.StraightFlush: return 80;
            case Hand.FourOfAKind: return 70;
            case Hand.FullHouse: return 50;
            case Hand.Flush: return 40;
            case Hand.Straight: return 30;
            case Hand.ThreeOfAKind: return 20;
            case Hand.TwoPair: return 10;
            case Hand.OnePair: return 5;
            case Hand.HighCard:
            default: return 0;
        }
    }
}