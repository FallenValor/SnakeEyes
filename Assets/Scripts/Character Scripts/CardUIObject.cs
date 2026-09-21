using TMPro;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UIElements;

public class CardUIObject : MonoBehaviour
{
    public Card card;

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text buttonText;

    [SerializeField] TMP_Text valueText;

    [SerializeField] TMP_Text costText;

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
            break;
            case GameAction.Shield:
            nameText.text = "Shield";
            break;
        }
        valueText.text = card.value.ToString();
        costText.text = card.cost.ToString();
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
                FindAnyObjectByType<CardRealizer>().cards.Add(this);
            }
        }
        else
        {
            transform.Translate(new Vector3(0,-50,0));
            buttonText.text = "Play";
            card.played = false;
            FindAnyObjectByType<Player>().mana += card.cost;
            FindAnyObjectByType<CardRealizer>().cards.Remove(this);
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
}
