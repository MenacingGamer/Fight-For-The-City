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
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        playerInputPanel.SetActive(false);
        isOpen = false;
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
        PlayerStats.Instance.playerLifes = 5;
        PlayerPrefs.SetString("PlayerName_1", PlayerStats.Instance.playerName);
        PlayerPrefs.SetInt("PlayerLifes_1", PlayerStats.Instance.playerLifes);
        startGamePanel.SetActive(true);
        welcomeText.text = "WELCOME " + PlayerStats.Instance.playerName + " NOW GO! SAVE THE CITY FROM THOSE ZOMBIES ";
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();  
#endif
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
