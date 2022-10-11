using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] public GameObject healthItemPrefab;
    [SerializeField] public GameObject ammoItemPrefab;
    [SerializeField] public Transform[] healthSpawnPoints;
    [SerializeField] public Transform[] ammoSpawnPoints;
    private Transform healthSpawnPoint;
    private Transform ammoSpawnPoint;
    private LevelManager levelManager;
    public bool canSpawnAmmo;
    public bool canSpawnHealth;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        SpawnHealth();
        SpawnAmmo();
    }

 
    public void SpawnHealth()
    {
        Debug.Log("I SPAWNED" + healthItemPrefab);
        healthSpawnPoint = healthSpawnPoints[Random.Range(0, healthSpawnPoints.Length)];
        Instantiate(healthItemPrefab, healthSpawnPoint.position, Quaternion.identity);

        canSpawnHealth = false;
        
        return;
    }

    public void SpawnAmmo()
    {
        Debug.Log("I SPAWNED" + ammoItemPrefab);
        ammoSpawnPoint = ammoSpawnPoints[Random.Range(0, ammoSpawnPoints.Length)];
        Instantiate(ammoItemPrefab, ammoSpawnPoint.position, Quaternion.identity);
      

        canSpawnAmmo = false;

        return;
    }
}
