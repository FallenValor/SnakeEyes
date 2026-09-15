using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Combatant
{
    public List<Card> cards = new List<Card>();

    List<GameObject> cardObjs = new List<GameObject>();

    [SerializeField] GameObject cardObject;

    [SerializeField] GameObject UIcanvas;

    [SerializeField] float cardSpread = 50;

    [SerializeField] CardRealizer realizer;


    public int maxHealth = 30;

    public int mana = 0;

    [SerializeField] TMP_Text Manaval;

    [SerializeField] TMP_Text HPval;
    [SerializeField] TMP_Text Armorval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = maxHealth;
        Attack = 1;
        Defense = 1;
        mana = 10;
        InitializeCards();
    }

    // Update is called once per frame
    void Update()
    {
        Manaval.text = "Mana: " + mana;
        HPval.text = "Health: " + Health + " / " + maxHealth;
        Armorval.text = "Armor: " + Armor;
    }

    void InitializeCards()
    {
        for(int i = 0; i < 4; i++)
        {
            switch (Random.Range(0,2))
            {
                case 0:
                cards.Add(new Card(GameAction.Attack, 4, 1));
                break;
                case 1:
                cards.Add(new Card(GameAction.Shield, 4, 1));
                break;
            }
        }
        UpdateCards();
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
            if(cards.Count % 2 == 1)
            {
                if(counter < Mathf.Ceil(cards.Count / 2.0f))
                {
                    cd.transform.Translate(new Vector3((Mathf.Ceil(cards.Count / 2.0f) - counter) * -cardSpread, -100, 0) );
                }
                else if(counter == Mathf.Ceil(cards.Count / 2.0f))
                {
                    cd.transform.Translate(new Vector3(0, -100, 0) );
                }
                else if (counter > Mathf.Ceil(cards.Count / 2.0f))
                {
                    cd.transform.Translate(new Vector3((counter - Mathf.Ceil(cards.Count / 2.0f)) * cardSpread, -100, 0) );
                }
            }
            else
            {
                if(counter <= Mathf.Ceil(cards.Count / 2.0f))
                {
                    cd.transform.Translate(new Vector3((Mathf.Ceil(cards.Count / 2.0f) + 1 - counter) * -cardSpread, -100, 0) );
                }
                else if (counter > Mathf.Ceil(cards.Count / 2.0f))
                {
                    cd.transform.Translate(new Vector3((counter - Mathf.Ceil(cards.Count / 2.0f)) * cardSpread, -100, 0) );
                }
            }
            counter += 1;
            //print(card.action + " " + card.value);
        }
    }
}
