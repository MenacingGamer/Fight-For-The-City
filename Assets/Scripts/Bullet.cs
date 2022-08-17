using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] Transform bulletFX;
    [SerializeField] Transform zombieHitFX;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(zombieHitFX, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(bulletFX, transform.position, Quaternion.identity);
        }
    }
}
