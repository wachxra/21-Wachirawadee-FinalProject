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
        Strength = _strengthStrategy.CalculateStrength(this);
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

public interface IHandStrengthStrategy
{
    int CalculateStrength(PokerHand hand);
}

public class RoyalFlushStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 450;
}

public class StraightFlushStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 400;
}

public class FourOfAKindStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 350;
}

public class FullHouseStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 300;
}

public class FlushStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 280;
}

public class StraightStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 250;
}

public class ThreeOfAKindStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 200;
}

public class TwoPairStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 150;
}

public class OnePairStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 100;
}

public class HighCardStrengthStrategy : IHandStrengthStrategy
{
    public int CalculateStrength(PokerHand hand) => 50;
}

public class RoyalFlush : PokerHand
{
    public RoyalFlush() : base("Royal Flush", new RoyalFlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Royal Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.RoyalFlush));
    }
}

public class StraightFlush : PokerHand
{
    public StraightFlush() : base("Straight Flush", new StraightFlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Straight Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.StraightFlush));
    }
}

public class FourOfAKind : PokerHand
{
    public FourOfAKind() : base("Four of a Kind", new FourOfAKindStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Four of a Kind, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.FourOfAKind));
    }
}

public class FullHouse : PokerHand
{
    public FullHouse() : base("Full House", new FullHouseStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Full House, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.FullHouse));
    }
}

public class Flush : PokerHand
{
    public Flush() : base("Flush", new FlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.Flush));
    }
}

public class Straight : PokerHand
{
    public Straight() : base("Straight", new StraightStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Straight, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.Straight));
    }
}

public class ThreeOfAKind : PokerHand
{
    public ThreeOfAKind() : base("Three of a Kind", new ThreeOfAKindStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Three of a Kind, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.ThreeOfAKind));
    }
}

public class TwoPair : PokerHand
{
    public TwoPair() : base("Two Pair", new TwoPairStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Two Pair, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.TwoPair));
    }
}

public class OnePair : PokerHand
{
    public OnePair() : base("One Pair", new OnePairStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a One Pair, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.OnePair));
    }
}

public class HighCard : PokerHand
{
    public HighCard() : base("High Card", new HighCardStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a High Card, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.HighCard));
    }
}