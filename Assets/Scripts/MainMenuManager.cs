using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject playerInputPanel;
    [SerializeField] GameObject startGamePanel;
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] TMP_Text welcomeText;
    [SerializeField] TMP_Text goGetThemText;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text bestSuriviorText;
    [SerializeField] TMP_Text bestSuriviorNameText;
    [SerializeField] TMP_Text zombiesKilledText;
    [SerializeField] TMP_Text zombiesKilledNumbersText;
    [SerializeField] TMP_Text waveReachedText;
    [SerializeField] TMP_Text waveReachedNumbersText;
    bool isOpen;
    private string bestPlayer;
    private int mostZombiesKills;
    private int mostWaves;
  
    // Start is called before the first frame update
    void Start()
    {
        CheckForBestGame();
        playerInputPanel.SetActive(false);
        isOpen = false;
    }

    public void CheckForBestGame()
    {
        bestPlayer = PlayerPrefs.GetString("BestPlayer", "MENACING GAMES");
        mostWaves = PlayerPrefs.GetInt("Waves", 5);
        mostZombiesKills = PlayerPrefs.GetInt("ZombiesKilled", 20);
    

        bestSuriviorNameText.text = "" + bestPlayer;
        zombiesKilledNumbersText.text = "" + mostZombiesKills;
        waveReachedNumbersText.text = "" + mostWaves;

   

    }

    public void NewGamePanel()
    {
        if(isOpen == false)
        {
            playerInputPanel.SetActive(true);
            isOpen = true;
        }
        else
        {
            playerInputPanel.SetActive(false);
            isOpen = false;
        }
        
    }

    public void EnterNameOfPlayer()
    {
        PlayerStats.Instance.playerName = playerNameInput.text;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("PlayerName", PlayerStats.Instance.playerName);
        startGamePanel.SetActive(true);
        playerNameText.text = "" + PlayerStats.Instance.playerName;
        welcomeText.text = "WELCOME ";
        goGetThemText.text = " LOOK FOR 4 LETTERS AROUND THE CITY TO UNLOCK THE HIDDEN LIST. " +
            "COMPLETE ALL OBJECTIVES ON THE LIST AND ESCAPE THROUGH THE PORTAL TO WIN.  ";
       
           
    }

    public void Exit()
    {

        Application.Quit();

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
