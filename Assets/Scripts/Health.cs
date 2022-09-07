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
            // animator.SetBool("isTakingDamage", true);
            animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 1f, Time.deltaTime * 10f));
            // Invoke(nameof(TakeDamageReset), .01f);
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
        animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
       // animator.SetBool("isTakingDamage", false);
    }

    public void PlayerDied()
    {
       
        levelManager.EndLevel();
    }
}
