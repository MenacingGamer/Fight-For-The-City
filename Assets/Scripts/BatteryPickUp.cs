using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private ObjectivesManager oM;
    private AudioManager audioManager;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        oM = FindObjectOfType<ObjectivesManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(itemName == "Battery")
            {
                oM.batteryCount++;
                audioManager.ItemPickUpSound();
            }
            if(itemName == "ScrewDriver")
            {
                oM.screwDriverCount++;
                audioManager.ItemPickUpSound();
            }
           Destroy(this.gameObject);
        }
    }

}
