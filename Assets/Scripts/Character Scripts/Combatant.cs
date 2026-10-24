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

    private int frozen;

    public int Frozen
    {
        get { return frozen; }
        set { frozen = value; }
    }
    private int evade;

    public int Evade
    {
        get { return evade; }
        set { evade = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StatusUpdate()
    {
        if(Evade > 0)
        {
            Evade -= 1;
        }
        if(Frozen > 0)
        {
            Frozen -= 1;
        }
    }
}
