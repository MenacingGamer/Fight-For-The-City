using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefabs;
    [SerializeField] public Transform[] enemySpawnPoints;
    private Transform spawnPoint;
    public int enemySpawnCount = 5;
    private int enemysToSpawn;
    private int spawned = 0;

    private AudioManager audioManager;
    private LevelManager levelManager;
   
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnCount = 5;
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemysToSpawn = enemySpawnCount * levelManager.waveCount; 
      

        if (levelManager.zombiesKilledThisRound == enemysToSpawn && levelManager.state == LevelManager.State.fighting)
        {
           
            spawned = 0;
           levelManager.zombiesKilledThisRound = 0;
            levelManager.state = LevelManager.State.counting;
            levelManager.spawnTimer = 60;
            audioManager.WaveEndSound();
        }
            
    }

    public void SpawnEnemys()
    {

        enemysToSpawn = enemySpawnCount * levelManager.waveCount;
    
        StartCoroutine(Spawning());
       
       

    }

      IEnumerator Spawning()
    {
       for(int i = 0; i < enemysToSpawn; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1f);
        }
        
        levelManager.state = LevelManager.State.fighting;

        yield break;
      
    }

    public void Spawn()
    {
        spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
        Instantiate(enemyPrefabs, spawnPoint.position, Quaternion.identity);
        spawned++;
    }

}
