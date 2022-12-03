using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] GameObject portalPartical;
    [SerializeField] GameObject eletricPartical;
    private AudioManager audioManager;
    public int repairedCount = 0;
    public int positionCount = 0;
    public bool portalOn = false;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        portalPartical.SetActive(false);
        eletricPartical.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
        if(repairedCount == 4 && positionCount == 2 && portalOn == false)
        {
            portalPartical.SetActive(true);
            eletricPartical.SetActive(true);
            audioManager.PortalRunning();
            portalOn = true;
        }
    }
}
