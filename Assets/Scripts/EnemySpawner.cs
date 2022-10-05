using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefabs;
    [SerializeField] public Transform[] enemySpawnPoints;
    private Transform spawnPoint;
    public int enemySpawnCount;

  
    private LevelManager levelManager;
   
    // Start is called before the first frame update
    void Start()
    {
    
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    
        if (levelManager.zombiesKilledThisRound == 5 && levelManager.state == LevelManager.State.fighting)
        {
           levelManager.zombiesKilledThisRound = 0;
            levelManager.state = LevelManager.State.counting;
            levelManager.spawnTimer = 60;
        }
            
    }

    public void SpawnEnemys()
    {

              spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];


            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                Instantiate(enemyPrefabs[i], spawnPoint.position, Quaternion.identity);
            }
             
    }

    

}
