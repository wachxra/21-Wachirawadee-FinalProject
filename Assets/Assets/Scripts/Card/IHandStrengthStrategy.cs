using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandStrengthStrategy
{
    int CalculateStrength(PokerHand hand);
}