using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefabs;
   

    private LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemys()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
          Instantiate(enemyPrefabs[i], transform.position, Quaternion.identity);
        }
        levelManager.spawnTimer = 90;
    }
}
