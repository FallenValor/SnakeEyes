using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField] public List<EnemyAction> actions;
    [SerializeField] public int baseHealth;
    [SerializeField] public int attack;
    [SerializeField] public int defense;
}
