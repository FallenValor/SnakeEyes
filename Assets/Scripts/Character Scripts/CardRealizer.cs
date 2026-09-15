using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardRealizer : MonoBehaviour
{
    public List<CardUIObject> cards;

    [SerializeField] Player player;
    [SerializeField] Enemy enemy;


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
        /*
            Refactor in the morning. Have the thing operate on the cards in the player object directly, 
            rather than going through the UI. Have UI objects change played value in cards rather than
            keeping that value themselves. Find a way to delete all children of game object.
        */
        
        for (int i = player.cards.Count - 1; i >= 0; i--)
        {
            if(player.cards[i].played)
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
        Debug.Log(enemy.counter);
        switch (enemy.type[0].actions[enemy.counter].action)
        {
            case GameAction.Attack:
            Attack(enemy, player, enemy.type[0].actions[enemy.counter].value);
            break;
            case GameAction.Shield:
            Shield(enemy, enemy.type[0].actions[enemy.counter].value);
            break;
        }
        if(enemy.counter < enemy.type[0].actions.Count - 1)
        {
            enemy.counter += 1;
        }
        else
        {
            enemy.counter = 0;
        }
        player.UpdateCards();
        player.mana += 1;
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
}
