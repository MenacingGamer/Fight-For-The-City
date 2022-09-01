using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(PlayerIsDead), .5f);

    }

    public void PlayerIsDead()
    {

    }
}
