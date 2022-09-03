using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    private LevelManager levelManager;
    private Animator animator;
    public int health = 100;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();    
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(PlayerIsDead), .5f);

    }

    public void PlayerIsDead()
    {
       
        levelManager.EndLevel();
    }
}
