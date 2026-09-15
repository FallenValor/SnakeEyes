using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Combatant
{
    [SerializeField] public List<EnemyType> type = new List<EnemyType>();
    
    [SerializeField] TMP_Text HPString;
    [SerializeField] TMP_Text ArmorString;
    [SerializeField] TMP_Text CardString;
    public int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = type[0].baseHealth;
        Attack = type[0].attack;
        Defense = type[0].defense;
    }

    // Update is called once per frame
    void Update()
    {
        HPString.text = Health.ToString();
        ArmorString.text = Armor.ToString();
    }
}
