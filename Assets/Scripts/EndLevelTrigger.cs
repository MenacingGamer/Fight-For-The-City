using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndLevelTrigger : MonoBehaviour
{
    private LevelManager levelManager;
    private Zombie zombie;
    private AudioManager audioManager;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Animator animator;
    [SerializeField] GameObject blueFire;
    [SerializeField] GameObject bigFire;
    [SerializeField] GameObject largeFlames;
    [SerializeField] GameObject endGamePanel;

    // Start is called before the first frame update
    void Start()
    {

        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
        largeFlames.SetActive(false);   
        blueFire.SetActive(false);
        bigFire.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.state = LevelManager.State.endGame;
            other.gameObject.SetActive(false);
            virtualCamera.enabled = true;           
            Invoke("EndGame", 2f);
            audioManager.PortalOff();
        }
    }

    private void EndGame()
    {
       
        animator.SetBool("EndGame", true);
        audioManager.PortalBuildUp();
        Invoke("BlueFire", 5f);
    }

    public void BlueFire()
    {
        blueFire.SetActive(true);
        Invoke("BigFire", 0.80f);
        audioManager.PortalBuildOff();
    }

    public void BigFire()
    {
       
        bigFire.SetActive(true);
        audioManager.PortalExplosion();
        Invoke("EndGamePanel", 0.75f);
        largeFlames.SetActive(true);
    }

    public void EndGamePanel()
    {
        endGamePanel.SetActive(true);
    
    }
}
