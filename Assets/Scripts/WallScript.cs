using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private float health = 10000f;

    private void Update()
    {
        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ApplyDamage(collision.gameObject.GetComponent<EnemyController>().damage);
        }
    }

    void ApplyDamage(float dmg)
    { 
        health -= dmg ;
        Debug.Log("Wall hit for : " + dmg + " Current Health : " + health);
    }
}
