using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] public float PortalRunningSoundFXVolume;
    [SerializeField] private AudioClip portalRunningSound;
    [Range(0f, 100f)]
    [SerializeField] public float PortalBuildUpSoundFXVolume;
    [SerializeField] private AudioClip portalBuildUpSound;
    [Range(0f, 100f)]
    [SerializeField] public float PortalExploisonSoundFXVolume;
    [SerializeField] private AudioClip portalExplosionSound;
    [Range(0f, 100f)]
    [SerializeField] public float fixingMechineSoundFXVolume;
    [SerializeField] private AudioClip fixingMechineSound;
    [Range(0f, 100f)]
    [SerializeField] public float illFixItSoundFXVolume;
    [SerializeField] private AudioClip illFixItSound;
    [Range(0f, 100f)]
    [SerializeField] public float letterPickUpSoundFXVolume;
    [SerializeField] private AudioClip letterPickUpSound;
    [Range(0f, 100f)]
    [SerializeField] public float wavestartSoundFXVolume;
    [SerializeField] private AudioClip waveStartSound;
    [Range(0f, 100f)]
    [SerializeField] public float waveEndSoundFXVolume;
    [SerializeField] private AudioClip waveEndSound;
    [Range(0f, 100f)]
    [SerializeField] public float itemPickupSoundFXVolume;
    [SerializeField] private AudioClip itemPickUp;
    [Range(0f, 100f)]
    [SerializeField] public float ammoPickupSoundFXVolume;
    [SerializeField] private AudioClip ammoPickUp;
    [Range(0f, 100f)]
    [SerializeField] public float needAmmoSoundFXVolume;
    [SerializeField] private AudioClip needAmmo;
    [Range(0f, 100f)]
    [SerializeField] public float healthPickupSoundFXVolume;
    [SerializeField] private AudioClip healthPickUp;
    [Range(0f, 100f)]
    [SerializeField] public float playerYeahSoundFXVolume;
    [SerializeField] private AudioClip yeahSound;
    [Range(0f, 100f)]
    [SerializeField] public float playerJumpSoundFXVolume;
    [SerializeField] private AudioClip jumpSound;
    [Range(0f, 100f)]
    [SerializeField] public float gunSoundFXVolume;
    [SerializeField] private AudioClip gunShot;
    [Range(0f, 100f)]
    [SerializeField] public float playerDieSoundFXVolume;
    [SerializeField] private AudioClip playerDieSound;
    [Range(0f, 100f)]
    [SerializeField] public float zombieEndSoundFXVolume;
    [SerializeField] private AudioClip zombieEndSound;
    [Range(0f, 100f)]
    [SerializeField] public float zombieImpactSoundFXVolume;
    [SerializeField] private AudioClip[] zombieImpacts;
    [Range(0f, 100f)]
    [SerializeField] public float zombieGruntSoundFXVolume;
    [SerializeField] private AudioClip[] zombieGrunts;
    [Range(0f, 100f)]
    [SerializeField] public float zombiePunchSoundFXVolume;
    [SerializeField] private AudioClip[] zombiePunchs;
    [Range(0f, 100f)]
    [SerializeField] public float playerTakeDamageSoundFXVolume;
    [SerializeField] private AudioClip[] playerTakeDamageSounds;
    [Range(0f, 100f)]
    [SerializeField] public float emptyGunSoundFXVolume;
    [SerializeField] private AudioClip emptyGunSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PortalRunning()
    {
        audioSource.loop = true;
        audioSource.clip = portalRunningSound;
        audioSource.volume = PortalRunningSoundFXVolume;
        audioSource.Play();
    }

    public void PortalOff()
    {
        audioSource.Stop();
        audioSource.loop = false;
    }

    public void PortalBuildUp()
    {
        audioSource.loop = true;
        audioSource.clip = portalBuildUpSound; 
        audioSource.volume = PortalBuildUpSoundFXVolume;
        audioSource.Play();
    }

    public void PortalBuildOff()
    {
        audioSource.Stop();
        audioSource.loop = false;
    }

    public void PortalExplosion()
    {
        audioSource.PlayOneShot(portalExplosionSound, PortalExploisonSoundFXVolume);
    }

    public void FixingMechine()
    {
        audioSource.PlayOneShot(fixingMechineSound, fixingMechineSoundFXVolume);
        audioSource.loop = true;
    }

    public void StopFixingSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
    }
    public void IllFixItSound()
    {
        audioSource.PlayOneShot(illFixItSound, illFixItSoundFXVolume);
    }
    public void ItemPickUpSound()
    {
        audioSource.PlayOneShot(itemPickUp, itemPickupSoundFXVolume);
    }

    public void LetterPickUpSound()
    {
        audioSource.PlayOneShot(letterPickUpSound, letterPickUpSoundFXVolume);
    }

    public void PlayerJumpSound()
    {
        audioSource.PlayOneShot(jumpSound, playerJumpSoundFXVolume);
    }
    public void WaveStartSound()
    {
        audioSource.PlayOneShot(waveStartSound, wavestartSoundFXVolume);
    }

    public void WaveEndSound()
    {
        audioSource.PlayOneShot(waveEndSound, waveEndSoundFXVolume);
    }

    public void PlayerYeahSound()
    {
        audioSource.PlayOneShot(yeahSound, playerYeahSoundFXVolume);
    }

    public void PlayerDieSound()
    {
        audioSource.PlayOneShot(playerDieSound, playerDieSoundFXVolume);
    }

    public void PlayerTakeDamageSound()
    {
        audioSource.PlayOneShot(playerTakeDamageSounds[Random.Range(0, zombieImpacts.Length)], playerTakeDamageSoundFXVolume);
    }

    public void GunShotSound()
    {
        audioSource.PlayOneShot(gunShot, gunSoundFXVolume);
    }

    public void HealthPickUpSound()
    {
        audioSource.PlayOneShot(healthPickUp, healthPickupSoundFXVolume);
    }

    public void ZombieEndSound()
    {
        audioSource.PlayOneShot(zombieEndSound, zombieEndSoundFXVolume);
    }

    public void NeedAmmoSound()
    {
        audioSource.PlayOneShot(needAmmo, needAmmoSoundFXVolume);
    }

    public void AmmoPickUpSound()
    {
        audioSource.PlayOneShot(ammoPickUp, ammoPickupSoundFXVolume);
    }
    public void ZombieImpactSounds()
    {
        
        audioSource.PlayOneShot(zombieImpacts[Random.Range(0, zombieImpacts.Length)], zombieImpactSoundFXVolume);
       
    }
    public void PlayGruntSound()
    {
        audioSource.PlayOneShot(zombieGrunts[Random.Range(0, zombieGrunts.Length)], zombieGruntSoundFXVolume);
    }

    public void ZombiePunchSound()
    {
        audioSource.PlayOneShot(zombiePunchs[Random.Range(0, zombiePunchs.Length)], zombiePunchSoundFXVolume);
    }

    public void EmptyGunSound()
    {
        audioSource.PlayOneShot(emptyGunSound, emptyGunSoundFXVolume);
    }
}
