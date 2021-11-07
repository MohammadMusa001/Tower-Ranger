using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] public float health, speed, damage, attackRange, attackRate;
    [SerializeField] EnemyData data;

    public bool canAttack = false ;
    private ObjectPooler objectPooler;
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    

    private void Awake()
    {
        health = data.health;
        speed = data.moveSpeed;
        damage = data.damage;
        attackRange = data.attackRange;
        attackRate = data.attackRate;

    }

    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        anim = this.GetComponent<Animator>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            anim.SetBool("Die", true);
            navMeshAgent.speed = 0;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        objectPooler.ReturnObjectToThePool(this.gameObject);
    }
}
