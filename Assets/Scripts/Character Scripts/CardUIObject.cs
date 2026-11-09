using TMPro;
using Unity.Collections;
//using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.InputSystem.EnhancedTouch;

public class CardUIObject : MonoBehaviour
{
    public Card card;
    public Player player;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text buttonText;

    [SerializeField] TMP_Text valueText;

    //[SerializeField] TMP_Text costText;

    //[SerializeField] Sprite cardSpriteAttack;
    //[SerializeField] Sprite cardSpriteShield;
    
    [SerializeField] GameObject cardImage;
    [SerializeField] GameObject cardColor;
    [SerializeField] GameObject cardBorder;
    [SerializeField] GameObject cardCost;

    [SerializeField] List <Color> cardSpriteColors;
    [SerializeField] List <Sprite> cardSpriteSymbols;
    [SerializeField] List<Sprite> cardSpriteDecos;
    [SerializeField] List <Sprite> cardSpriteCosts;
    [SerializeField] List <Sprite> cardSpriteValues;
    [SerializeField] Sprite cardSpriteCircle;
    [SerializeField] Sprite cardSpriteBorder;

    bool played = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(card.action)
        {
            case GameAction.Attack:
                nameText.text = "Attack";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[0];
                break;
            case GameAction.Shield:
                nameText.text = "Shield";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[1];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[1];
                break;
            case GameAction.Heal:
                nameText.text = "Heal";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[2];
                break;
            case GameAction.Poison:
                nameText.text = "Poison";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[3];
                
                break;
            case GameAction.Freeze:
                nameText.text = "Freeze";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[4];
                break;
            case GameAction.Feint:
                nameText.text = "Feint";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[5];
                break;
            case GameAction.Evade:
                nameText.text = "Evade";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[6];
                break;
            case GameAction.Focus:
                nameText.text = "Focus";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[7];
                break;
            
        }
        valueText.text = card.value.ToString();
        //cardCost.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[7];
        //MouseChecker();
    }

    public void Init(Card cd)
    {
        card = cd;
    }

    public void OnClick()
    {
        //Debug.Log("Clicked.");
        if(!card.played)
        {
            if(FindAnyObjectByType<Player>().mana >= card.cost)
            {
                transform.Translate(new Vector3(0,50,0));
                buttonText.text = "Recall";
                card.played = true;
                FindAnyObjectByType<Player>().mana -= card.cost;
            }
        }
        else
        {
            transform.Translate(new Vector3(0,-50,0));
            buttonText.text = "Play";
            card.played = false;
            FindAnyObjectByType<Player>().mana += card.cost;
        }
    }

    void OnDestroy()
    {
        int numChildren = transform.childCount;
        for (int i = numChildren - 1; i > 0; i-- )
        {
            Destroy(transform.GetChild(i).gameObject);
            //Debug.Log("I AM DESTROYING!!!");
        }
    }
    /*
    void MouseChecker()
    {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y,10));
        if(pos.x > gameObject.transform.position.x - 2 &&
        pos.x < gameObject.transform.position.x + 2 &&
        pos.y < gameObject.transform.position.y + 2 &&
        pos.y > gameObject.transform.position.y - 2)
        {
            gameObject.transform.Translate(2,0,0);

        }
                    print(pos);
    }
    */
}
