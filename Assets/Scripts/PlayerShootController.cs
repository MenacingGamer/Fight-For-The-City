using UnityEngine;
using Cinemachine;
using StarterAssets;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerShootController : MonoBehaviour
{

    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] float reloadTime = 1f;
    [SerializeField] float nextTimeToFire = 0;
    [SerializeField] int damage;
    [SerializeField] public int bullets;
    [SerializeField] public int magazineSize;
    [SerializeField] public int magazineCount;
    [SerializeField] LayerMask aimColliderLayerMask;
    [SerializeField] GameObject bulletFX;
    [SerializeField] GameObject zombieHitFX;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] TMP_Text ammoText;

    private bool canShoot = true;
    private bool reloading;
    private StarterAssetsInputs starterAssetsInputs;
    private AudioManager audioManager;
    private Animator animator;
    private Health health;
    private PlayerInput _playerInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        magazineCount = 12;
        bullets = magazineSize;
        ammoText.text = "AMMO : " + bullets + "/" + magazineCount;
        health = GetComponentInChildren<Health>();
        audioManager = GetComponent<AudioManager>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        reloading = false;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
       
        ammoText.text = "AMMO : " + bullets + "/" + magazineCount;
        if (health.playerIsDead == true || reloading == true)
        {
            return;
        }
        if(magazineCount <= 0 && bullets <= 0)
        {
            magazineCount = 0;
            audioManager.NeedAmmoSound();
            reloading = true;
            return;
        }
         

        if (starterAssetsInputs.shoot && bullets <= 0)
         {
             audioManager.EmptyGunSound();
            reloading = true;
            StartCoroutine(Reload());
          
         }

         if (starterAssetsInputs.shoot && bullets >= 1 && Time.time >= nextTimeToFire)
         {
            nextTimeToFire = Time.time + 1f / fireRate;
           Shoot(); 
        }
        else
        {
            starterAssetsInputs.shoot = false;
        }
        
    }

       public void ReloadNow()
    {
        reloading = true;
        StartCoroutine(Reload());
    }

     public IEnumerator Reload()
    {
        if (magazineCount >= 1)
        {

            yield return new WaitForSeconds(reloadTime);
            bullets = magazineSize;
            magazineCount--;
            starterAssetsInputs.shoot = false;
            reloading = false;

           
        }

    }



   void Shoot()
    {
       
        bullets--;
            muzzleFlash.Play();
            audioManager.GunShotSound();
            //shooting cam shake
            CameraShake.Instance.CamShake(.5f, .1f);

            Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

            RaycastHit hitInfo;


            if (Physics.Raycast(ray, out hitInfo, range, aimColliderLayerMask))
            {
                if (hitInfo.collider.gameObject.GetComponent<Zombie>() != null)
                {
                    audioManager.ZombieImpactSounds();
                    GameObject zomBlood = Instantiate(zombieHitFX, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(zomBlood, 2f);
                    hitInfo.collider.gameObject.SendMessage("TakeDamage", damage);
                }
                else
                {
                    GameObject hitFX = Instantiate(bulletFX, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(hitFX, 2f);
                }
            }

       // yield return new WaitForSeconds(nextTimeToFire);
    }
 
  }
