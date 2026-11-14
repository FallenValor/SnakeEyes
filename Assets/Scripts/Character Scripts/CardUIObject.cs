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

    [SerializeField] TMP_Text descriptionText;

    //[SerializeField] TMP_Text costText;

    //[SerializeField] Sprite cardSpriteAttack;
    //[SerializeField] Sprite cardSpriteShield;

    [SerializeField] GameObject cardImage;
    [SerializeField] GameObject cardColor;
    [SerializeField] GameObject cardBorder;
    [SerializeField] GameObject cardCost;
    [SerializeField] GameObject cardTooltips;

    [SerializeField] List<Color> cardSpriteColors;
    [SerializeField] List<Sprite> cardSpriteSymbols;
    [SerializeField] List<Sprite> cardSpriteDecos;
    [SerializeField] List<Sprite> cardSpriteCosts;
    [SerializeField] List<Sprite> cardSpriteValues;
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
        int valChange = 1;
        switch (card.action)
        {
            case GameAction.Attack:
                nameText.text = "Attack";
                descriptionText.text = "Attack - Attack enemy for " + (card.value * valChange).ToString() + " points of health.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[0];
                valChange = player.Attack;
                break;
            case GameAction.Shield:
                nameText.text = "Shield";
                descriptionText.text = "Shield - Defend from attack for " + (card.value * valChange).ToString() + " points of shield.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[1];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[1];
                valChange = player.Defense;
                break;
            case GameAction.Heal:
                nameText.text = "Heal";
                descriptionText.text = "Heal - Gain" + (card.value * valChange).ToString() + "points of health.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[4];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[3];
                break;
            case GameAction.Poison:
                nameText.text = "Poison";
                descriptionText.text = "Poison - Deal" + (card.value * valChange).ToString() + "points of true damage. (This damage is not stopped by shield)";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[2];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[2];
                valChange = player.Attack;
                break;
            case GameAction.Freeze:
                nameText.text = "Freeze";
                descriptionText.text = "Freeze - Enemy cannot perform attack for set amount of turns.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[3];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[2];
                break;
            case GameAction.Feint:
                nameText.text = "Feint";
                descriptionText.text = "Feint - Attack enemy for " + (card.value * valChange).ToString() + " points of health and Defend from attack for " + (card.value * valChange).ToString() + " points of shield.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[0];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[1];
                break;
            case GameAction.Evade:
                nameText.text = "Evade";
                descriptionText.text = "Evade - Avoid incoming enemy attack and negates all damage for this turn.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[6];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[3];
                break;
            case GameAction.Focus:
                nameText.text = "Focus";
                descriptionText.text = "Focus - You will recieve "+ (card.value * valChange).ToString() + " additional mana next turn.";
                cardImage.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteSymbols[5];
                cardColor.GetComponent<UnityEngine.UI.Image>().color = cardSpriteColors[4];
                break;

        }
        valueText.text = (card.value * valChange).ToString();
        cardCost.GetComponent<UnityEngine.UI.Image>().sprite = cardSpriteCosts[card.cost - 1];
        //MouseChecker();
    }

    public void Init(Card cd)
    {
        card = cd;
    }

    public void OnClick()
    {
        //Debug.Log("Clicked.");
        if (!card.played)
        {
            if (FindAnyObjectByType<Player>().mana >= card.cost)
            {
                transform.Translate(new Vector3(0, 50, 0));
                buttonText.text = "Recall";
                card.played = true;
                FindAnyObjectByType<Player>().mana -= card.cost;
            }
        }
        else
        {
            transform.Translate(new Vector3(0, -50, 0));
            buttonText.text = "Play";
            card.played = false;
            FindAnyObjectByType<Player>().mana += card.cost;
        }
    }

    void OnDestroy()
    {
        int numChildren = transform.childCount;
        for (int i = numChildren - 1; i > 0; i--)
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

    public void ShowTooltips()
    {
        cardTooltips.SetActive(true);
    }
    public void HideTooltips()
    {
        cardTooltips.SetActive(false);
    }
}
