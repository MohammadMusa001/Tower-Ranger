using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy                                 ;
    [SerializeField] private float        time, xSpawnPos, ySpawnPos, zSpawnPos ;
    [SerializeField] private Vector3      spawnPos                              ;
    


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        spawnPos = new Vector3(Random.Range(-xSpawnPos, xSpawnPos), ySpawnPos, zSpawnPos);
        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemies());
    }
}
