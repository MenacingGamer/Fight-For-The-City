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
    public bool playerIsDead;

    private void Awake()
    {
        playerIsDead = false;
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
        if (!playerIsDead)
        {
            animator.SetBool("isTakingDamage", true);
           // Invoke(nameof(TakeDamageReset), .01f);
            audioManager.ZombiePunchSound();
            health -= damage;
            audioManager.PlayerTakeDamageSound();
            if (health <= 0)
            {
                animator.SetBool("isDead", true);
                playerIsDead = true;
                audioManager.PlayerDieSound();
                Invoke(nameof(PlayerDied), .5f);
            }
        }
       
    }
    public void TakeDamageReset()
    {
        animator.SetBool("isTakingDamage", false);
    }

    public void PlayerDied()
    {
       
        levelManager.EndLevel();
    }
}
