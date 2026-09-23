using TMPro;
using UnityEngine;
public enum UpgradeType
{
    Attack,
    Defense,
    Health,
    Heal,
    Mana
}
public class UpgradeUI : MonoBehaviour
{
    public UpgradeType type;
    public TMP_Text text; 
    public CardRealizer controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(type != UpgradeType.Mana)
        {
            switch(Random.Range(1,5))
            {
                case 1:
                type = UpgradeType.Attack;
                text.text = "Attack + 1";
                break;
                case 2:
                type = UpgradeType.Defense;
                text.text = "Defense + 1";
                break;
                case 3:
                type = UpgradeType.Health;
                text.text = "Health + 4";
                break;
                case 4:
                type = UpgradeType.Heal;
                text.text = "Heal 20";
                break;
            }
        }
        else
        {
            text.text = "Starting Mana + 1";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        switch(type)
        {
            case UpgradeType.Attack:
            controller.player.Attack += 1;
            break;
            case UpgradeType.Defense:
            controller.player.Defense += 1;
            break;
            case UpgradeType.Health:
            controller.player.maxHealth += 4;
            controller.player.Health += 4;
            break;
            case UpgradeType.Mana:
            controller.player.manaStartBonus += 1;
            break;
            case UpgradeType.Heal:
            if(controller.player.Health + 20 > controller.player.maxHealth)
            {
                controller.player.Health = controller.player.maxHealth;
            }
            else
            {
                controller.player.Health += 20;
            }
            break;
        }
        if(type != UpgradeType.Mana)
        {
            controller.UpgradeShopEnd();
        }
        else
        {
            controller.WinUI();
        }
    }
}
