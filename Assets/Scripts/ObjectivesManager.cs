using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] GameObject letter_S;
    [SerializeField] GameObject letter_E;
    [SerializeField] GameObject letterE;
    [SerializeField] GameObject letter_K;

    [SerializeField] GameObject objectivesPanel;
    private int letterCount;
    


    // Start is called before the first frame update
    void Start()
    {
        letterCount = 0;
        letter_S.SetActive(false);
        letter_E.SetActive(false);
        letterE.SetActive(false);
        letter_K.SetActive(false);
        objectivesPanel.SetActive(false);
    }

    private void Update()
    {
        if(letterCount == 4)
        {
            objectivesPanel.SetActive(true);
        }
    }
    public void Set_S_Active()
    {
        letter_S.SetActive(true);
        letterCount++;
    }

    public void Set_E_Active()
    {
        letter_E.SetActive(true);
        letterCount++;
    }

    public void Set_2E_Active()
    {
        letterE.SetActive(true);
        letterCount++;
    }

    public void Set_K_Active()
    {
        letter_K.SetActive(true);
        letterCount++;
    }
}
