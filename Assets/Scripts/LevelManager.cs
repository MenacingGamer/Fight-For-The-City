using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;
using System.Data;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanelCanvas;
    [SerializeField] GameObject endLevelCanvas;
    [SerializeField] TMP_Text zombiesKilledText;
    [SerializeField] TMP_Text spawnTimerText;
    [SerializeField] public float spawnTimer;
                     private int zombiesKilled;
    private EnemySpawner enemySpawner;
    private PlayerShootController shootController;
    private StarterAssetsInputs _input;
    public bool gamePaused;
    public bool playingRound;

    private void Awake()
    {
       
        _input = FindObjectOfType<StarterAssetsInputs>();
        shootController = FindObjectOfType<PlayerShootController>();    
        enemySpawner = FindObjectOfType<EnemySpawner>();
        spawnTimerText.text = "NEXT WAVE IN : " + spawnTimer;
        PausePanelCanvas.SetActive(false);
        endLevelCanvas.SetActive(false);
        zombiesKilledText.text = "ZOMBIES KILLED : " + zombiesKilled; 
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shootController.canShoot = true;
        gamePaused = false;
        playingRound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.pause) 
        {
            PauseGame();        
        }

        if (spawnTimer > 0 && playingRound == false)
        {
            spawnTimer -= Time.deltaTime;
            TimerFormat(spawnTimer);
        }
        else
        {
            playingRound = true;
            spawnTimer = 0;
            StartNewRound();
           
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

    public void StartNewRound()
    {
        if(enemySpawner.spawnedEnemys == false)
        {
            enemySpawner.SpawnEnemys();
        }
        
    }
    public void PauseGame()
    {
        if (!gamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            shootController.canShoot = false;
            gamePaused = true;
            PausePanelCanvas.SetActive(true);
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            shootController.canShoot = true;
            Time.timeScale = 1;
            gamePaused = false;
            PausePanelCanvas.SetActive(false);
        }
        _input.pause = false;
    }

    public void ZombieCount()
    {
        zombiesKilled++;
    }

    public void EndLevel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        endLevelCanvas.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void ReSpawn()
    {
        Time.timeScale = 1;
        gamePaused = false;
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
