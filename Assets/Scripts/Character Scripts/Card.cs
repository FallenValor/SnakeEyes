using System;
using UnityEngine;

public enum GameAction
{
    Attack,
    Shield,
}
[System.Serializable]
public class Card
{
    public GameAction action;
    public int value;
    public bool played;
    public int cost;

    public Card(GameAction act, int val, int cos)
    {
        action = act;
        value = val;
        cost = cos;
    }
}
