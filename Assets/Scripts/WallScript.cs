using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private float maxHealth = 10000f;
    private float currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        PauseMenu.isGameOver = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ApplyDamage(other.gameObject.GetComponent<EnemyController>().damage);
            other.GetComponent<Animator>().SetBool("Attack", true);
        }
    }

    void ApplyDamage(float dmg)
    { 
        currentHealth -= dmg * Time.deltaTime ;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Wall hit for : " + dmg + " Current Health : " + currentHealth);
    }
}
