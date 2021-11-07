using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowScript : MonoBehaviour
{

    private FireScript fs;
    public float arrowDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(arrowDamage);

            Debug.Log("Enemy hit with :" + arrowDamage);
        }
        GetComponent<TrailRenderer>().enabled = false;
    }
}
