using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Health health;
    AudioManager audioManager;
    SpawnItem spawnItem;

    private void Awake()
    {
       
        spawnItem = FindObjectOfType<SpawnItem>();
        health = FindObjectOfType<Health>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(health.health <= 90)
            {
                spawnItem.canSpawnHealth = true;
                audioManager.PlayerYeahSound();
                audioManager.HealthPickUpSound();
                health.health = 100;
                Destroy(this.gameObject);
              
            } 
         
        }
    }
}
