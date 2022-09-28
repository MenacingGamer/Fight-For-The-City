using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.health = 100;
            Destroy(this.gameObject);
        }
    }
}
