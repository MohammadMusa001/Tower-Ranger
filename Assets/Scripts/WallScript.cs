using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private float health = 10000f;

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ApplyDamage(other.gameObject.GetComponent<EnemyController>().damage);
        }
    }

    void ApplyDamage(float dmg)
    { 
        health -= dmg * Time.deltaTime ;
        Debug.Log("Wall hit for : " + dmg + " Current Health : " + health);
    }
}
