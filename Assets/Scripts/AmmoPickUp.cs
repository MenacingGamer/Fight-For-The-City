using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    PlayerShootController playerShootController;
    // Start is called before the first frame update
    void Start()
    {
        playerShootController = FindObjectOfType<PlayerShootController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerShootController.ammo += 50;
            Destroy(this.gameObject);
        }
    }
}
