using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObjectToBePooled(GameObject objectToBePooled)
    {
        if(objectPool.TryGetValue(objectToBePooled.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateNewObject(objectToBePooled);
            }
            else
            {
                GameObject _objectToBePooled = objectList.Dequeue();
                _objectToBePooled.SetActive(true);
                return _objectToBePooled;
            }
        }
        else
        {
            return CreateNewObject(objectToBePooled);
        }
    }

    private GameObject CreateNewObject(GameObject objectToBeCreated)
    {
        GameObject newObject = Instantiate(objectToBeCreated);
        newObject.name = objectToBeCreated.name;
        return newObject;
    }

    public void ReturnObjectToThePool(GameObject gameObject)
    {
        if(objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }
        gameObject.SetActive(false);
    }    
}
