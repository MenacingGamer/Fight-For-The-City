using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public string playerName;
    [SerializeField] public string BestPlayerName;
    [SerializeField] public int waveReached = 0;
    [SerializeField] public int zombiesKilled = 0;
    [SerializeField] public int mostZombiesKilled = 0;
    [SerializeField] public int bestWaveReached = 0;
    [SerializeField] public bool escapedLevel = false;
    
    public static PlayerStats Instance;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

}
