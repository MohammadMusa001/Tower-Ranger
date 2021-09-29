using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] public float health, speed, damage, attackRange, attackRate;
    [SerializeField] EnemyData data;

    public bool canAttack = false ;
    private ObjectPooler objectPooler;
    

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
        //StartCoroutine(Attack());
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            objectPooler.ReturnObjectToThePool(this.gameObject);
        }
    }

    /*IEnumerator Attack()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            Debug.Log("Shots Fired");
            WallScript wallScript = hit.transform.GetComponent<WallScript>();
            if (wallScript != null)
            { 
                Debug.Log("wall hit");
                StartCoroutine(Attack());
            }
        }

        yield return new WaitForSeconds(attackRate);
    }*/
}
