using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PokerHand : Card
{
    public string HandName { get; protected set; }
    public int Strength { get; protected set; }
    private IHandStrengthStrategy _strengthStrategy;

    protected PokerHand(string handName, int strength)
    {
        HandName = handName;
        Strength = strength;
    }

    protected PokerHand(string handName, IHandStrengthStrategy strengthStrategy)
    {
        HandName = handName;
        _strengthStrategy = strengthStrategy;
        Strength = _strengthStrategy.CalculateStrength(this); // �ӹǳ Strength
    }

    public abstract void DisplayHandInfo();

    public enum Rank
    {
        Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5,
        Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11, Queen = 12, King = 13
    }
    public virtual int CompareStrength(PokerHand otherHand)
    {
        return Strength.CompareTo(otherHand.Strength);
    }

    public int CompareStrength(int otherStrength)
    {
        return Strength.CompareTo(otherStrength);
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
            case Hand.RoyalFlush: return 450;
            case Hand.StraightFlush: return 400;
            case Hand.FourOfAKind: return 350;
            case Hand.FullHouse: return 300;
            case Hand.Flush: return 280;
            case Hand.Straight: return 250;
            case Hand.ThreeOfAKind: return 200;
            case Hand.TwoPair: return 150;
            case Hand.OnePair: return 100;
            case Hand.HighCard: return 50;
            default: return 0;
        }
    }
}