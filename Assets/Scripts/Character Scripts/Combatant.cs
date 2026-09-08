using UnityEngine;

public class Combatant : MonoBehaviour
{
    private int HP;

    public int Health
    {
        get { return HP; }
        set { HP = value; }
    }
    private int AR;

    public int Armor
    {
        get { return AR; }
        set { AR = value; }
    }

    private int AT;

    public int Attack
    {
        get { return AT; }
        set { AT = value; }
    }

    private int DF;

    public int Defense
    {
        get { return DF; }
        set { DF = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
