using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    private void Start()
    {
       
        
    }

    private void Update()
    {
        float speed = 5f;
        transform.Translate(Vector3.forward * speed);
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }
}
