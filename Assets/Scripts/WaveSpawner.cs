using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveAction
{
    public string     name       ;
    public float      delay      ;
    public GameObject prefab     ;
    public int        spawnCount ;
}

[System.Serializable]
public class Wave
{
    public string           name    ;
    public List<WaveAction> actions ;
}

public class WaveSpawner : MonoBehaviour
{
    public List<Wave> waves;
    private Wave _currentWave;
    public Wave currentWave { get { return _currentWave; } }
    private float delayFactor;
    [SerializeField] private float  xSpawnPos, ySpawnPos, zSpawnPos;

    private int currentWaveCount = 0;
    private int maxWaveCount = 2;

    private ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        delayFactor = 1.0f;
        while(true && currentWaveCount<=maxWaveCount)
        {
            foreach(Wave w in waves)
            {
                _currentWave = w;
                foreach(WaveAction waveAction in w.actions)
                {
                    if(waveAction.delay > 0)
                    {
                        yield return new WaitForSeconds(waveAction.delay * delayFactor);
                    }

                    if(waveAction.prefab != null && waveAction.spawnCount>0)
                    {
                        for(int i = 0; i < waveAction.spawnCount;i++)
                        {
                           GameObject _prefab = objectPooler.GetObjectToBePooled(waveAction.prefab);
                            _prefab.transform.position = new Vector3(Random.Range(-xSpawnPos, xSpawnPos), ySpawnPos, zSpawnPos);
                        }
                        currentWaveCount++;
                    }
                }
                yield return null;
            }
            yield return null;
        }
    }



}
