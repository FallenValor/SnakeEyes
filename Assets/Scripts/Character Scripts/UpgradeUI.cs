using TMPro;
using UnityEngine;
public enum UpgradeType
{
    Attack,
    Defense,
    Health
}
public class UpgradeUI : MonoBehaviour
{
    public UpgradeType type;
    public TMP_Text text; 
    public CardRealizer controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(Random.Range(1,4))
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
        }
        controller.UpgradeShopEnd();
    }
}
