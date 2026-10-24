using System;
using UnityEngine;

public enum GameAction
{
    Attack,
    Shield,
    Heal,
    Poison,
    Freeze,
    Feint,
    Evade,
    Focus,
    
}
[System.Serializable]
public class Card
{
    public GameAction action;
    public int value;
    public bool played;
    public int cost;

    public bool upgraded = false;

    public Card(GameAction act, int val, int cos)
    {
        action = act;
        value = val;
        cost = cos;
    }
}
