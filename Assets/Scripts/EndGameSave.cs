using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSave : MonoBehaviour
{
    [SerializeField] TMP_Text survivorNameText;
    [SerializeField] TMP_Text zombiesKilledNumbersText;
    [SerializeField] TMP_Text wavesSurvivedNumbersText;
    private LevelManager levelManager;

    private string bestPlayer;
    private int mostZombiesKills;
    private int mostWaves;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        bestPlayer = PlayerStats.Instance.playerName;
        survivorNameText.text = "YOU SURVIVED AND ESCAPED " + bestPlayer;
        mostZombiesKills = levelManager.zombiesKilled;
        zombiesKilledNumbersText.text = "" + mostZombiesKills;
        mostWaves = levelManager.waveCount;
        wavesSurvivedNumbersText.text = "" + mostWaves;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   public void SaveAndExit()
    {
        PlayerPrefs.SetString("BestPlayer", bestPlayer);
        PlayerPrefs.SetInt("Waves", mostWaves);
        PlayerPrefs.SetInt("ZombiesKilled", mostZombiesKills);
 
        SceneManager.LoadScene(0);
    }
}
