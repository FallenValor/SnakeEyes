using TMPro;
using UnityEngine;
public enum UpgradeTypeWave
{
    Heal,
    CardAdd,
    CardUpgrade
}
public class UpgradeUIWave : MonoBehaviour
{
    public UpgradeTypeWave type;
    public TMP_Text text; 
    public CardRealizer controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(Random.Range(1,4))
        {
            case 1:
            type = UpgradeTypeWave.Heal;
            text.text = "Heal 30";
            break;
            case 2:
            type = UpgradeTypeWave.CardAdd;
            text.text = "Add Card";
            break;
            case 3:
            type = UpgradeTypeWave.CardUpgrade;
            text.text = "Upgrade Card";
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
            case UpgradeTypeWave.Heal:
            if(controller.player.Health + 30 > controller.player.maxHealth)
            {
                controller.player.Health = controller.player.maxHealth;
            }
            else
            {
                controller.player.Health += 30;
            }
            controller.UpgradeShopEnd();
            break;
            case UpgradeTypeWave.CardAdd:
            controller.AddCardMenu();
            break;
            case UpgradeTypeWave.CardUpgrade:
            controller.UpgradeCardMenu();
            break;
        }
    }
}
