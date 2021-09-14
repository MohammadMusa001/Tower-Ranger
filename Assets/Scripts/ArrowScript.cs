using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [HideInInspector] private Rigidbody rb;
    private FireScript fs;
    private float damage;
    public bool arrowHasCollided = false;

    private void Awake()
    {
         rb = GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        damage = 1;
        rb.isKinematic = false;
    }

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage * 25);
            Debug.Log("Enemy hit with :" + damage);
            rb.isKinematic = true;

        }
        arrowHasCollided = true;
        
    }
}
