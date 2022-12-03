using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatPositionSensor : MonoBehaviour
{
    private PortalController PortalController;

    // Start is called before the first frame update
    void Start()
    {
        PortalController = FindObjectOfType<PortalController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SAT"))
        {
            PortalController.positionCount++;
            this.gameObject.SetActive(false);
        }
    
    }
}
