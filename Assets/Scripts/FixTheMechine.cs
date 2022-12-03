using StarterAssets;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class FixTheMechine : MonoBehaviour
{
    [SerializeField] GameObject smokePartical;
    [SerializeField] GameObject sparkPartical;
    [SerializeField] GameObject lazerBeam;
    [SerializeField] Slider fixingSlider;
    [SerializeField] GameObject sliderPanel;

    private GameObject player;
    private AudioManager audioManager;
    private ObjectivesManager objectivesManager;
    private PlacingBattery battery;
    private StarterAssetsInputs _input;
    private PortalController portalController;
    private ThirdPersonController thirdPersonController;
    private float fixCounter;
    private bool repaired = false;
    public bool isRepairing = false;
 

    // Start is called before the first frame update
    void Start()
    {
        fixCounter = 0f;
        fixingSlider.value = 0;
        sliderPanel.SetActive(false);
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
        battery = FindObjectOfType<PlacingBattery>();
        portalController = FindObjectOfType<PortalController>();
        audioManager = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        _input = FindObjectOfType<StarterAssetsInputs>();
        objectivesManager = FindObjectOfType<ObjectivesManager>();
        smokePartical.SetActive(true);
        sparkPartical.SetActive(true);
         lazerBeam.SetActive(false);
    }

    private void Update()
    {

        fixingSlider.value = fixCounter;

       if(battery.hasPower && repaired == true)
        {
            lazerBeam.SetActive(true);       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isRepairing == false && repaired == false)
        {
            audioManager.IllFixItSound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player") && objectivesManager.screwDriverCount == 1 && repaired == false)
        {

            sliderPanel.SetActive(true);
           

            if (_input.action)
            {
               isRepairing = true;
                thirdPersonController.isFixing = true;
                fixCounter++;
                fixingSlider.value = fixCounter;
                player.GetComponentInChildren<Animator>().SetBool("isFixing", true);
                audioManager.FixingMechine();

                if (fixCounter >= 500f)
                {
                    portalController.repairedCount++;
                    isRepairing = false;
                    thirdPersonController.isFixing = false;
                    repaired = true;
                    smokePartical.SetActive(false);
                    sparkPartical.SetActive(false);
                    sliderPanel.SetActive(false);
                    _input.action = false;
                    audioManager.StopFixingSound();
                    player.GetComponentInChildren<Animator>().SetBool("isFixing", false);
                 
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && fixCounter <= 1000f)
        {
            audioManager.StopFixingSound();
            isRepairing = false;
            thirdPersonController.isFixing = false;
            fixCounter = 0;
            sliderPanel.SetActive(false);
            _input.action = false;
            player.GetComponentInChildren<Animator>().SetBool("isFixing", false);
        
        }
    }




}
