using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions = new Transform[0];
    [SerializeField] private int currentTarget;
    private NavMeshAgent navMeshAgent;
    private EnemyController enemyController;
    [SerializeField] EnemyData data;
    private float attackRange;
    private float distanceFromPlayer;
    private float wallZ;
    private GameObject player;

    

    private void Awake()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<EnemyController>();
        navMeshAgent.speed = data.moveSpeed;
        attackRange = data.attackRange;
        player = GameObject.FindGameObjectWithTag("Player");

        currentTarget = 0;

        if(GameObject.FindGameObjectWithTag("Wall")!= null)
        {
            wallZ = GameObject.FindGameObjectWithTag("Wall").transform.position.z;
        }

        
        if (GameObject.FindGameObjectWithTag("Wall") == null)
        {
            navMeshAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else
        {
            navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, wallZ);
        }
        

        
    }


    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Wall") == null)
        {
            navMeshAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        
        if (player != null)
        {
            distanceFromPlayer = Vector3.Distance(player.transform.position,transform.position);
            if(distanceFromPlayer <= attackRange )
            {
                enemyController.canAttack = true;
                navMeshAgent.isStopped = true;
            }
            else
            {
                navMeshAgent.isStopped = false;
            }

        }

        if(navMeshAgent.destination == null)
        {
            currentTarget++;
            navMeshAgent.destination = targetPositions[currentTarget].position;
        }
    }
}
