using TMPro;
using UnityEngine;
public enum UpgradeTypeWave
{
    Mana,
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
            type = UpgradeTypeWave.Mana;
            text.text = "Starting Mana + 1";
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
            case UpgradeTypeWave.Mana:
            controller.player.manaStartBonus += 1;
            controller.WinUI();
            break;
            case UpgradeTypeWave.CardAdd:
            controller.AddCardMenu();
            break;
        }
    }
}
