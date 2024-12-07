using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PokerHand : Card
{
    public string HandName { get; protected set; }
    public int Strength { get; protected set; }
    private IHandStrengthStrategy _strengthStrategy;

    // Constructor for direct strength value (for specific hand types if needed)
    protected PokerHand(string handName, int strength)
    {
        HandName = handName;
        Strength = strength;
    }

    // Constructor with strategy for calculating strength
    protected PokerHand(string handName, IHandStrengthStrategy strengthStrategy)
    {
        HandName = handName;
        _strengthStrategy = strengthStrategy;
        Strength = _strengthStrategy.CalculateStrength(this); // Calculate strength dynamically
    }

    // Abstract method to be implemented by specific hand types
    public abstract void DisplayHandInfo();

    // Enum for Rank (card values)
    public enum Rank
    {
        Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5,
        Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11, Queen = 12, King = 13
    }

    // Compare Strength method to compare hands or strengths
    public virtual int CompareStrength(PokerHand otherHand)
    {
        return Strength.CompareTo(otherHand.Strength);
    }

    public int CompareStrength(int otherStrength)
    {
        return Strength.CompareTo(otherStrength);
    }

    // Enum for Suit (card suits)
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    // Get random rank for cards
    public Rank GetRandomRank()
    {
        return (Rank)UnityEngine.Random.Range(1, 14);
    }

    // Get random suit for cards
    public Suit GetRandomSuit()
    {
        return (Suit)UnityEngine.Random.Range(0, 4);
    }

    // Enum for Poker Hand types
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

    // Static method for getting the damage of a particular hand
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

// Strategy Pattern Interface for Strength Calculation
public interface IHandStrengthStrategy
{
    int CalculateStrength(PokerHand hand);
}

// Concrete strategies for different hand strengths
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

// Concrete implementation for a specific Poker hand
public class RoyalFlush : PokerHand
{
    public RoyalFlush() : base("Royal Flush", new RoyalFlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Royal Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.RoyalFlush)); // Display damage
    }
}

public class StraightFlush : PokerHand
{
    public StraightFlush() : base("Straight Flush", new StraightFlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Straight Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.StraightFlush)); // Display damage
    }
}

public class FourOfAKind : PokerHand
{
    public FourOfAKind() : base("Four of a Kind", new FourOfAKindStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Four of a Kind, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.FourOfAKind)); // Display damage
    }
}

public class FullHouse : PokerHand
{
    public FullHouse() : base("Full House", new FullHouseStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Full House, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.FullHouse)); // Display damage
    }
}

public class Flush : PokerHand
{
    public Flush() : base("Flush", new FlushStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Flush, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.Flush)); // Display damage
    }
}

public class Straight : PokerHand
{
    public Straight() : base("Straight", new StraightStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Straight, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.Straight)); // Display damage
    }
}

public class ThreeOfAKind : PokerHand
{
    public ThreeOfAKind() : base("Three of a Kind", new ThreeOfAKindStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Three of a Kind, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.ThreeOfAKind)); // Display damage
    }
}

public class TwoPair : PokerHand
{
    public TwoPair() : base("Two Pair", new TwoPairStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a Two Pair, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.TwoPair)); // Display damage
    }
}

public class OnePair : PokerHand
{
    public OnePair() : base("One Pair", new OnePairStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a One Pair, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.OnePair)); // Display damage
    }
}

public class HighCard : PokerHand
{
    public HighCard() : base("High Card", new HighCardStrengthStrategy()) { }

    public override void DisplayHandInfo()
    {
        Debug.Log("This is a High Card, Strength: " + Strength);
        Debug.Log("Damage: " + GetDamage(Hand.HighCard)); // Display damage
    }
}
