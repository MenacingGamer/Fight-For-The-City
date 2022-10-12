using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPickup : MonoBehaviour
{
    public ObjectivesManager ObjectivesManager;
    public string letterName;
    public GameObject letterPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           if(letterName == "S")
            {
                ObjectivesManager.Set_S_Active();
            }
           if(letterName == "E")
            {
                ObjectivesManager.Set_E_Active();
            }
           if(letterName == "2E")
            {
                ObjectivesManager.Set_2E_Active();
            }
            if (letterName == "K")
            {
                ObjectivesManager.Set_K_Active();
            }

        }
        Destroy(this.gameObject);
    }
}
