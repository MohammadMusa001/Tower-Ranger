using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool  SharedInstance ;
    
    public GameObject         objectToPool   ;
    public int                amountToPool   ;


    [HideInInspector]
    public List<GameObject>   pooledObjects  ;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject currentArrow;
        for (int i = 0; i < amountToPool; i++)
        {
            currentArrow = Instantiate(objectToPool);
            currentArrow.SetActive(false);
            pooledObjects.Add(currentArrow);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                Rigidbody objectRb = pooledObjects[i].gameObject.GetComponent<Rigidbody>();
                objectRb.velocity = Vector3.zero;
                objectRb.angularVelocity = Vector3.zero;
                objectRb.isKinematic = true;

                return pooledObjects[i];
            }
        }
        return null;
    }

}
