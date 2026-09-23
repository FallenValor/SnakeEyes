using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardRealizer : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject button;
    [SerializeField] GameObject upgradeCard;
    public List<GameObject> upgrades = new List<GameObject>();
    public float upgradeSpace = 200;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject winui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndTurn()
    {
        PlayerRealization();
        EnemyRealization();
        PlayerTurnUpdate();
        EnemyTurnUpdate();
    }

    private void EnemyTurnUpdate()
    {
        if(enemy.Health <= 0)
        {
            if (enemy.enemyCounter < enemy.type.Count - 1)
            {
                enemy.enemyCounter += 1;
                UpgradeShopStart();
            }
            else
            {
                enemy.enemyCounter = 0;
                UpgradeShopStartWave();
            }
            
        }
        else
        {
            string txt = "Next Action:\n";
            switch (enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].action)
            {
                case GameAction.Attack:
                    txt += "Attack, " + enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].value.ToString() + " * " + enemy.Attack.ToString();
                    break;
                case GameAction.Shield:
                    txt += "Shield, " + enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].value.ToString() + " * " + enemy.Defense.ToString();
                    break;
            }
            enemy.CardString.text = txt;
        }
        
    }

    private void PlayerTurnUpdate()
    {
        if(player.Health <= 0)
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        int multi = Random.Range(1, 4);
        switch (Random.Range(0, 2))
        {
            case 0:
                player.AddCard(GameAction.Attack, 4,1, multi);
                break;
            case 1:
                player.AddCard(GameAction.Shield, 4,1, multi);
                break;
        }
        player.UpdateCards();
        if(player.manaFill < 6)
        {
            player.manaFill += 1;
        }
        player.mana = player.manaFill + player.manaStartBonus;

    }

    private void EnemyRealization()
    {
        if(enemy.Health > 0)
        {
            switch (enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].action)
            {
                case GameAction.Attack:
                    Attack(enemy, player, enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].value);
                    break;
                case GameAction.Shield:
                    Shield(enemy, enemy.type[enemy.enemyCounter].actions[enemy.nextIndex].value);
                    break;
            }
            enemy.nextIndex = Random.Range(0, enemy.type[enemy.enemyCounter].actions.Count);
        }

    }

    private void PlayerRealization()
    {
        for (int i = player.cards.Count - 1; i >= 0; i--)
        {
            if (player.cards[i].played)
            {
                switch (player.cards[i].action)
                {
                    case GameAction.Attack:
                        Attack(player, enemy, player.cards[i].value);
                        break;
                    case GameAction.Shield:
                        Shield(player, player.cards[i].value);
                        break;
                }
                player.cards.Remove(player.cards[i]);
            }
        }
    }

    void Attack(Combatant attacker, Combatant defender, int val)
    {
        int damage = val * attacker.Attack;
        if(defender.Armor > 0)
        {
            if(defender.Armor > damage)
            {
                defender.Armor -= damage;
            }
            else
            {
                damage -= defender.Armor;
                defender.Armor = 0;
                defender.Health -= damage;
            }
        }
        else
        {
            defender.Health -= damage;
        }
    }

    void Shield(Combatant defender, int val)
    {
        defender.Armor += val * defender.Defense;
    }

    public void Reload()
    {
        SceneManager.LoadScene("3D TestScene");
    }
    void UpgradeShopStart()
    {
        player.cards.Clear();
        player.UpdateCards();
        enemy.HPString.text = "";
        enemy.ArmorString.text = "";
        enemy.CardString.text = "";
        enemy.gameObject.SetActive(false);
        button.SetActive(false);
        for(int i = 0; i < 3; i++)
        {
            var up = Instantiate(upgradeCard, player.UIcanvas.transform);
            up.transform.Translate((upgradeSpace * i) - upgradeSpace, 0, 0);
            up.GetComponent<UpgradeUI>().controller = this;
            upgrades.Add(up);
        }
    }

    void UpgradeShopStartWave()
    {
        player.cards.Clear();
        player.UpdateCards();
        enemy.HPString.text = "";
        enemy.ArmorString.text = "";
        enemy.CardString.text = "";
        enemy.gameObject.SetActive(false);
        button.SetActive(false);
        for(int i = 0; i < 1; i++)
        {
            var up = Instantiate(upgradeCard, player.UIcanvas.transform);
            up.transform.Translate((upgradeSpace * i) - upgradeSpace, 0, 0);
            up.GetComponent<UpgradeUI>().controller = this;
            up.GetComponent<UpgradeUI>().type = UpgradeType.Mana;
            upgrades.Add(up);
        }
    }
    public void UpgradeShopEnd()
    {
        foreach(GameObject obj in upgrades)
        {
            Destroy(obj);
        }
        enemy.gameObject.SetActive(true);
        button.SetActive(true);
        player.InitializeCards();
        enemy.Initialize();
    }

    public void WinUI()
    {
        Instantiate(winui,canvas.transform);
    }
}
