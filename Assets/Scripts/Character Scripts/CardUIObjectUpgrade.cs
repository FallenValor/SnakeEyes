using TMPro;
using Unity.Collections;
//using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CardUIObjectUpgrade : MonoBehaviour
{
    public Card card;
    public Player player;
    public CardRealizer controller;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text buttonText;

    [SerializeField] TMP_Text valueText;

    [SerializeField] TMP_Text costText;

    [SerializeField] Sprite cardSpriteAttack;
    [SerializeField] Sprite cardSpriteShield;
    [SerializeField] SpriteRenderer cardImage;

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
            valueText.text = (card.value * player.Attack).ToString();
                cardImage.sprite = cardSpriteAttack;
                break;
            case GameAction.Shield:
                nameText.text = "Shield";
                valueText.text = (card.value * player.Defense).ToString();
                cardImage.sprite = cardSpriteShield;
                break;
            case GameAction.Heal:
                nameText.text = "Heal";
                valueText.text = card.value.ToString();
                cardImage.sprite = cardSpriteShield;
                break;
            case GameAction.Poison:
                nameText.text = "Poison";
                valueText.text = (card.value * player.Attack).ToString();;
                cardImage.sprite = cardSpriteAttack;
                break;
            case GameAction.Freeze:
                nameText.text = "Freeze";
                valueText.text = card.value.ToString();
                cardImage.sprite = cardSpriteAttack;
                break;
            case GameAction.Feint:
                nameText.text = "Feint";
                valueText.text = (card.value * player.Attack).ToString() + " ATK + " + (card.value * player.Defense).ToString() + " AMR";
                cardImage.sprite = cardSpriteAttack;
                break;
            case GameAction.Evade:
                nameText.text = "Evade";
                valueText.text = card.value.ToString();
                cardImage.sprite = cardSpriteAttack;
                break;
            case GameAction.Focus:
                nameText.text = "Focus";
                valueText.text = card.value.ToString();
                cardImage.sprite = cardSpriteAttack;
                break;
        }
        costText.text = card.cost.ToString();
        //MouseChecker();
        if(card.upgraded)
        {
            buttonText.text = "UPGRADED";
        }
    }

    public void Init(Card cd)
    {
        card = cd;
    }

    public void OnClick()
    {
        if(!card.upgraded)
        {
            switch(card.action)
            {
                case GameAction.Attack:
                case GameAction.Shield:
                case GameAction.Poison:
                case GameAction.Feint:
                card.value += 2;
                break;
                case GameAction.Heal:
                card.value += 5;
                card.cost -= 1;
                break;
                case GameAction.Evade:
                case GameAction.Freeze:
                case GameAction.Focus:
                card.value += 1;
                break;

            }
            card.upgraded = true;
            controller.UpgradeShopEnd();
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
