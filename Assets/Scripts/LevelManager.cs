using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject endLevelCanvas;
    [SerializeField] TMP_Text zombiesKilledText;
    [SerializeField] TMP_Text spawnTimerText;
    [SerializeField] public float spawnTimer;
                    private int zombiesKilled;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        spawnTimerText.text = "NEXT WAVE IN : " + spawnTimer;
        endLevelCanvas.SetActive(false);
        zombiesKilledText.text = "ZOMBIES KILLED : " + zombiesKilled; 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            TimerFormat(spawnTimer);
        }
        else
        {
            spawnTimer = 0;
            enemySpawner.SpawnEnemys();
        }
     
       // spawnTimerText.text = "NEXT WAVE IN : " + spawnTimer;
        zombiesKilledText.text = "ZOMBIES KILLED : " + zombiesKilled;
    }

    void TimerFormat(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        spawnTimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void ZombieCount()
    {
        zombiesKilled++;
    }

    public void EndLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        endLevelCanvas.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReSpawn()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {   
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();  
#endif
        
    }
}
