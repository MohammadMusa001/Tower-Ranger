using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Data",fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] public float health, moveSpeed, damage, attackRange , attackRate ;
    
}
