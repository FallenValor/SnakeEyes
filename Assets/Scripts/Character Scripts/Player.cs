using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Combatant
{
    public List<Card> cards = new List<Card>();

    public List<GameObject> cardObjs = new List<GameObject>();

    [SerializeField] GameObject cardObject;

    [SerializeField] public GameObject UIcanvas;

    [SerializeField] float cardSpread = 10;
    [SerializeField] float cardOffsetX = 10;
    [SerializeField] float cardOffsetY = 10;

    [SerializeField] CardRealizer realizer;


    public int maxHealth = 30;

    public int mana = 0;

    public int manaFill = 1;

    [SerializeField] TMP_Text Manaval;

    [SerializeField] TMP_Text HPval;
    [SerializeField] TMP_Text Armorval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = maxHealth;
        Attack = 1;
        Defense = 1;
        mana = manaFill;
        InitializeCards();
    }

    // Update is called once per frame
    void Update()
    {
        Manaval.text = "Mana: " + mana;
        HPval.text = "Health: " + Health + " / " + maxHealth;
        Armorval.text = "Armor: " + Armor;
    }

    public void InitializeCards()
    {
        for(int i = 0; i < 4; i++)
        {
            int multi = Random.Range(1,4);
            switch (Random.Range(0,2))
            {
                case 0:
                AddCard(GameAction.Attack, 4,1,multi);
                break;
                case 1:
                AddCard(GameAction.Shield, 4,1,multi);
                break;
            }
        }
        UpdateCards();
        manaFill = 1;
        mana = manaFill;
    }

    public void AddCard(GameAction action, int value, int cost, int multi)
    {
        cards.Add(new Card(action, value * multi, cost * multi));
    }

    public void UpdateCards()
    {
        int counter = 1;
        foreach(GameObject obj in cardObjs)
        {
            Destroy(obj.gameObject);
        }
        foreach(Card card in cards)
        {
            GameObject cd = Instantiate(cardObject, UIcanvas.transform);
            cd.GetComponent<CardUIObject>().Init(card);
            cardObjs.Add(cd);
            cd.transform.Translate(new Vector3((counter * cardSpread) + cardOffsetX, cardOffsetY, 0) );
            cd.GetComponent<CardUIObject>().player = this;
            counter += 1;
            //print(card.action + " " + card.value);
        }
    }
}
