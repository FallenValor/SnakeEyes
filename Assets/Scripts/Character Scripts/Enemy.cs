using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Combatant
{
    [SerializeField] public List<EnemyType> type = new List<EnemyType>();
    
    [SerializeField] public TMP_Text HPString;
    [SerializeField] public TMP_Text ArmorString;
    [SerializeField] public TMP_Text CardString;
    public int nextIndex = 0;
    public int enemyCounter = 0;
    public int waveMultiplier = 1;
    GameObject model;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        HPString.text = "Health: " + Health.ToString();
        ArmorString.text = "Armor: " + Armor.ToString();
        
    }

    public void Initialize()
    {
        nextIndex = Random.Range(0, type[enemyCounter].actions.Count);
        Health = type[enemyCounter].baseHealth * waveMultiplier;
        Attack = type[enemyCounter].attack * waveMultiplier;
        Defense = type[enemyCounter].defense;
        string txt = "Next Action:\n";
        switch(type[enemyCounter].actions[nextIndex].action)
        {
            case GameAction.Attack:
            txt += "Attack, " + type[enemyCounter].actions[nextIndex].value.ToString() + " * " + Attack.ToString();
            break;
            case GameAction.Shield:
            txt += "Shield, " + type[enemyCounter].actions[nextIndex].value.ToString() + " * " + Defense.ToString();
            break;
        }
        CardString.text = txt;
        if(model != null)
        {
            Destroy(model);
        }
        model = Instantiate(type[enemyCounter].modelPrefab, gameObject.transform);
        model.transform.SetPositionAndRotation(gameObject.transform.position,gameObject.transform.rotation);
    }
}
