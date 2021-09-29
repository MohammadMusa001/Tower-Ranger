using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] 
    private NavMeshAgent    navMeshAgent   ;
    private EnemyController enemyController;
    [SerializeField] 
    private EnemyData       data           ;
    private float           attackRange    ;
    private GameObject      player         ;

    

    private void Awake()
    {    
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<EnemyController>();
        navMeshAgent.speed = data.moveSpeed;
        attackRange = data.attackRange;
        player = GameObject.FindGameObjectWithTag("Player");    
    }
}
