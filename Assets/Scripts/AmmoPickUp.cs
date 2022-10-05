using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    PlayerShootController playerShootController;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerShootController = FindObjectOfType<PlayerShootController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.ItemPickUpSound();
            audioManager.AmmoPickUpSound();
            playerShootController.clips = 12;
            Destroy(this.gameObject);
        }
    }
}
