using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    PlayerShootController playerShootController;
    AudioManager audioManager;
    SpawnItem spawnItem;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        spawnItem = FindObjectOfType<SpawnItem>();
        audioManager = FindObjectOfType<AudioManager>();
        playerShootController = FindObjectOfType<PlayerShootController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playerShootController.magazineCount < 12)
            {
                spawnItem.canSpawnAmmo = true;
                playerShootController.magazineCount = 12;
                audioManager.ItemPickUpSound();
                audioManager.AmmoPickUpSound();
                playerShootController.StartCoroutine(playerShootController.Reload());
                Destroy(this.gameObject);
              
            }
      
        }
    }
}
