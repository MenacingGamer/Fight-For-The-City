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
    [SerializeField] GameObject[] batterys;
    [SerializeField] GameObject screwDriver;
    [SerializeField] GameObject objectivesPanel;
    [SerializeField] TMP_Text batterysText;
    [SerializeField] TMP_Text screwDriverText;
    [SerializeField] TMP_Text fix4MechinesText;
    private int letterCount;
    public int batteryCount;
    public int screwDriverCount;
    private LevelManager levelManager;
    private PortalController pC;

    // Start is called before the first frame update
    void Start()
    {
        pC = FindObjectOfType<PortalController>();
        levelManager = FindObjectOfType<LevelManager>();

        for(int i = 0; i < batterys.Length; i++)
        {
            batterys[i].SetActive(false);
        }
       
        batteryCount = 0;
        letterCount = 0;
        screwDriver.SetActive(false);
        letter_S.SetActive(false);
        letter_E.SetActive(false);
        letterE.SetActive(false);
        letter_K.SetActive(false);
        objectivesPanel.SetActive(false);
    }

    private void Update()
    {
      
        if (letterCount == 4)
        {
            objectivesPanel.SetActive(true);
            TurnOnBatterys();
            screwDriver.SetActive(true);
            letterCount = 0;
        }
        if(fix4MechinesText != null) { fix4MechinesText.text = "FIX PORTAL MECHINES " + pC.repairedCount + " / 4"; }
        if(pC.repairedCount == 4) { fix4MechinesText.fontStyle = FontStyles.Strikethrough; }
        if(screwDriverText != null) { screwDriverText.text = "FIND A SCREW DRIVER "; }
        if(screwDriverCount == 1) { screwDriverText.fontStyle = FontStyles.Strikethrough; }
        if(batterysText != null) { batterysText.text = "FIND 4 BATTERYS " + batteryCount + " / 4"; }
        if(batteryCount == 4) { batterysText.fontStyle = FontStyles.Strikethrough; }
    }

    void TurnOnBatterys()
    {
        for (int i = 0; i < batterys.Length; i++)
        {
            batterys[i].SetActive(true);
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
