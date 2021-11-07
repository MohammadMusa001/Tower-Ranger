using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    //[SerializeField] private float  xSpawnPos, ySpawnPos, zSpawnPos;

    private int currentWaveCount = 0;
    private int maxWaveCount     = 2;

    private float wallPosZ, wallPosY;
    public Transform spawnPos;
    private bool canKeepCount;

    private ObjectPooler objectPooler;

    private void Start()
    {
        canKeepCount = false;
        objectPooler = FindObjectOfType<ObjectPooler>();
        StartCoroutine(SpawnLoop());
        wallPosZ = GameObject.FindGameObjectWithTag("Wall").transform.position.z;
        wallPosY = GameObject.FindGameObjectWithTag("Wall").transform.position.y;
    }

    private void Update()
    {
        if(canKeepCount)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {
                Debug.Log("all enemies are dead");
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(3);
            }
        }
    }

    IEnumerator SpawnLoop()
    {
        delayFactor = 1.0f;
        while(true && currentWaveCount<maxWaveCount)
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
                            _prefab.GetComponent<Animator>().SetBool("Run", true);                           
                            _prefab.transform.localPosition = new Vector3(Random.Range(-40 , 40), 
                                spawnPos.position.y, spawnPos.position.z);
                            canKeepCount = true;

                            if(GameObject.FindGameObjectWithTag("Wall")!= null)
                            {
                                _prefab.GetComponent<NavMeshAgent>().SetDestination(new Vector3(_prefab.transform.position.x,
                                wallPosY, wallPosZ));
                            }
                            
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
