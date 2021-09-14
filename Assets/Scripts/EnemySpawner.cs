using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] float time = 3f;
    [SerializeField] private Vector3 spawnPos;


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        spawnPos = new Vector3(Random.Range(-48, 48), 1.87f, 47);
        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemies());
    }
}
