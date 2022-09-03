using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] public float gunSoundFXVolume;
    [SerializeField] private AudioClip gunShot;
    [Range(0f, 100f)]
    [SerializeField] public float playerDieSoundFXVolume;
    [SerializeField] private AudioClip playerDieSound;
    [Range(0f, 100f)]
    [SerializeField] public float zombieImpactSoundFXVolume;
    [SerializeField] private AudioClip[] zombieImpacts;
    [Range(0f, 100f)]
    [SerializeField] public float zombieGruntSoundFXVolume;
    [SerializeField] private AudioClip[] zombieGrunts;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GunShotSound()
    {
        audioSource.PlayOneShot(gunShot, gunSoundFXVolume);
    }

    public void ZombieImpactSounds()
    {
        
        audioSource.PlayOneShot(zombieImpacts[Random.Range(0, zombieImpacts.Length)], zombieImpactSoundFXVolume);
       
    }
    public void PlayGruntSound()
    {
        Debug.Log("PLAYING");
        audioSource.PlayOneShot(zombieGrunts[Random.Range(0, zombieGrunts.Length)], zombieGruntSoundFXVolume);
    }
}
