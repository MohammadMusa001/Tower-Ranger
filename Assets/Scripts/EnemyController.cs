using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            objectPooler.ReturnObjectToThePool(this.gameObject);
        }
    }

    private void Die ()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        
        if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            Debug.Log("Shots Fired");
            FireScript fireScript = hit.transform.GetComponent<FireScript>();
            if (fireScript != null)
            {
                
                Debug.Log("Player hit");
                StartCoroutine(Attack());
            }
        }

        yield return new WaitForSeconds(attackRate);
    }
}
