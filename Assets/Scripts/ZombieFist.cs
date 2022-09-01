using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFist : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] public int damage;

    private void Awake()
    {
        health = FindObjectOfType<Health>();  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.TakeDamage(damage);
            Debug.Log("hitting you");
        }
    }
}
