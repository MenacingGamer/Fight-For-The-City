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
    public enum State
    {
        counting,
        spawning,
        fighting,
    }
    
    [SerializeField] GameObject PausePanelCanvas;
    [SerializeField] GameObject endLevelCanvas;
    [SerializeField] GameObject _startedWaveText;
    [SerializeField] TMP_Text startedWaveText;
    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text waveCounterText;
    [SerializeField] TMP_Text nextWaveText;
    [SerializeField] TMP_Text zombiesKilledText;
    [SerializeField] TMP_Text zombiesKilledCounterText;
    [SerializeField] TMP_Text spawnTimerText;
    [SerializeField] public float spawnTimer;                                       
    private PlayerShootController shootController;
    private StarterAssetsInputs _input;
    private EnemySpawner enemySpawner;
    private SpawnItem spawnItem;
    private AudioManager audioManager;
   // private ObjectivesManager objectivesManager;
    public bool gamePaused;
    public int zombiesKilled;
    public int zombiesKilledThisRound = 0;
    public int waveCount;
    public int itemSpawn;
    public State state;

    private void Awake()
    {
      //  objectivesManager = FindObjectOfType<ObjectivesManager>();
        audioManager = FindObjectOfType<AudioManager>();    
        spawnItem = FindObjectOfType<SpawnItem>();
        _input = FindObjectOfType<StarterAssetsInputs>();
        shootController = FindObjectOfType<PlayerShootController>();    
        enemySpawner = FindObjectOfType<EnemySpawner>();
        nextWaveText.text = "NEXT WAVE ";      
        zombiesKilledText.text = "ZOMBIES KILLED";
        zombiesKilledCounterText.text = "" + zombiesKilled;
        PausePanelCanvas.SetActive(false);
        endLevelCanvas.SetActive(false);
        waveText.enabled = false;
        _startedWaveText.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        zombiesKilledThisRound = 0;
        state = State.counting;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gamePaused = false;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_input.pause) 
        {
            PauseGame();        
        }

        if (state == State.counting)
        {
            
            spawnTimerText.enabled = true;
            nextWaveText.enabled = true;
            waveText.enabled = false;
            waveCounterText.enabled = false;
            spawnTimer -= Time.deltaTime;
            TimerFormat(spawnTimer);
            if (spawnTimer <= 0)
            {
                state = State.spawning;
                 StartNewRound();
            }
        }
        if(state == State.spawning)
        {
            waveText.enabled = true;
            waveCounterText.enabled = true;
            spawnTimerText.enabled = false;
            nextWaveText.enabled = false;
            spawnTimer = 0;
            
           
        }
        if(state == State.fighting) { _startedWaveText.SetActive(false); }
            startedWaveText.text = "WAVE " + waveCount;
        if (waveText != null) { waveText.text = " WAVE "; }
        if (waveCounterText != null) { waveCounterText.text = ""+ waveCount;}
         if(nextWaveText != null) { nextWaveText.text = " NEXT WAVE ";}
        zombiesKilledText.text = "ZOMBIES KILLED";
        zombiesKilledCounterText.text = "" + zombiesKilled;

     
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
     
        
        if(state == State.spawning)
        {
            waveCount++;
            _startedWaveText.SetActive(true);
            audioManager.WaveStartSound();
           
          
            enemySpawner.SpawnEnemys();
          if(waveCount % 2 == 0 && spawnItem.canSpawnAmmo == true)
            {
                spawnItem.SpawnAmmo();
            }
          if(waveCount % 4 == 0 && spawnItem.canSpawnHealth == true)
            {
                spawnItem.SpawnHealth();
            }
        }
       
    }
    public void PauseGame()
    {
        if (!gamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            gamePaused = true;
            PausePanelCanvas.SetActive(true);
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            gamePaused = false;
            PausePanelCanvas.SetActive(false);
        }
        _input.pause = false;
    }

    public void ZombieCount()
    {
        zombiesKilled++;
        zombiesKilledThisRound++;
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
