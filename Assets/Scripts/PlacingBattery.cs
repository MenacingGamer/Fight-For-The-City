using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingBattery : MonoBehaviour
{
    [SerializeField] GameObject batPlaceHolder;
    [SerializeField] GameObject battery;

    ObjectivesManager objectivesManager;
    private StarterAssetsInputs _input;
    public bool hasPower = false;

    // Start is called before the first frame update
    void Start()
    {
        batPlaceHolder.SetActive(true);
        battery.SetActive(false);
        _input = FindObjectOfType<StarterAssetsInputs>();
        objectivesManager = FindObjectOfType<ObjectivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && objectivesManager.batteryCount == 4)
        {
            if (_input.action)
            {
                batPlaceHolder.SetActive(false);
                battery.SetActive(true);
                this.hasPower = true;
                _input.action = false;
            }
        }
    }
}
