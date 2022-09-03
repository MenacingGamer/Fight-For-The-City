using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private AudioManager audioManager;
    private LevelManager levelManager;
    private Animator animator;
    public int health = 100;
    private Slider healthBarSlider;

    private void Awake()
    {
        audioManager = GetComponent<AudioManager>();
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
        animator.SetBool("isTakingDamage", true);
        Invoke(nameof(TakeDamageReset), .01f);
        audioManager.ZombiePunchSound();
        health -= damage;
        audioManager.PlayerTakeDamageSound();
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            audioManager.PlayerDieSound();
            Invoke(nameof(PlayerIsDead), .5f);
        }
       

    }
    public void TakeDamageReset()
    {
        animator.SetBool("isTakingDamage", false);
    }

    public void PlayerIsDead()
    {
       
        levelManager.EndLevel();
    }
}
