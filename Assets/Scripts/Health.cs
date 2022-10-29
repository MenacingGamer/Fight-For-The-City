
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
   
    private AudioManager audioManager;
    private LevelManager levelManager;
    private Animator animator;
    public int health = 25;
    public Slider healthBarSlider;
    public bool playerIsDead;
    public GameObject damagePanel;
  
          

    private void Awake()
    {
        damagePanel.SetActive(false);
        playerIsDead = false;
        audioManager = GetComponent<AudioManager>();
       // healthBarSlider = FindObjectOfType<Canvas>().GetComponentInChildren<Slider>();
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
            CameraShake.Instance.CamShake(5f, .5f);
            animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 1f, Time.deltaTime * 10f));
            //player aim turn off
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
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
        animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 0f, Time.deltaTime * 20f));
        //player ain turn on
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
     
    }

    public void PlayerDied()
    {
       
        levelManager.EndLevel();
    }
}
