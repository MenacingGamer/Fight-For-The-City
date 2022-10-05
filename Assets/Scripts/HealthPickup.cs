using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Health health;
    AudioManager audioManager;
    private void Awake()
    {
        health = FindObjectOfType<Health>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlayerYeahSound();
            audioManager.HealthPickUpSound();
            health.health = 100;
            Destroy(this.gameObject);
        }
    }
}
