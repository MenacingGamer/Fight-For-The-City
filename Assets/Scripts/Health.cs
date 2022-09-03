using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private LevelManager levelManager;
    private Animator animator;
    public int health = 100;
    private Slider healthBarSlider;

    private void Awake()
    {
        healthBarSlider = FindObjectOfType<Canvas>().GetComponentInChildren<Slider>();
        animator = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();    
    }

    private void Update()
    {
        healthBarSlider.value = health;
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
