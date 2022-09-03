using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject endLevelCanvas;

    private void Awake()
    {
        endLevelCanvas.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
