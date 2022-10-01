using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
   
    private AudioManager audioManager;
    private LevelManager levelManager;
    private Animator animator;
    public int health = 25;
    private Slider healthBarSlider;
    public bool playerIsDead;
    public GameObject damagePanel;
  
          

    private void Awake()
    {
        damagePanel.SetActive(false);
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

            damagePanel.SetActive(true);
            audioManager.ZombiePunchSound();
            health -= damage;
            audioManager.PlayerTakeDamageSound();
            Invoke(nameof(TakeDamageReset), .5f);
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
        damagePanel.SetActive(false);
        animator.SetBool("isTakingDamage", false);
    }

    public void PlayerDied()
    {
       
        levelManager.EndLevel();
    }
}
