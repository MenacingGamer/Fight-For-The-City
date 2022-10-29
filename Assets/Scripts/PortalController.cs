using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] GameObject portalPartical;
    [SerializeField] GameObject eletricPartical;
    public int repairedCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        portalPartical.SetActive(false);
        eletricPartical.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(repairedCount == 4)
        {
            portalPartical.SetActive(true);
            eletricPartical.SetActive(true);
        }
    }
}
