using UnityEngine;
using Cinemachine;
using StarterAssets;
using TMPro;


public class PlayerShootController : MonoBehaviour
{
  
    [SerializeField] CinemachineVirtualCamera aimCamera;
    [SerializeField] LayerMask aimColliderLayerMask;
    [SerializeField] Transform pfBullet;
    [SerializeField] Transform spawnBulletPosition;
    [SerializeField] Transform bulletFX;
    [SerializeField] Transform zombieHitFX;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damage;
    [SerializeField] public int bullets;
    [SerializeField] public int clips;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] public bool canShoot;
    private bool reloading;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private AudioManager audioManager;
    private Animator animator;
    private Health health;
 

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        clips = 12;
        bullets = 15;
        ammoText.text = "AMMO : " + bullets + "/" + clips;
        health = GetComponentInChildren<Health>();
        audioManager = GetComponent<AudioManager>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        ammoText.text = "AMMO : " + bullets + "/" + clips;
        if  (health.playerIsDead == false && canShoot)
        {
            if (starterAssetsInputs.shoot && bullets >= 1)
            {
                Shoot();
            }
           
              else if (starterAssetsInputs.shoot && bullets <= 0)
            {
                if (canShoot)
                {
                    canShoot = false;
                    bullets = 0;
                    starterAssetsInputs.shoot = false;
                    audioManager.EmptyGunSound();
                    Invoke("Reload", 1f);
                   
                }


            }
            starterAssetsInputs.shoot = false;
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
        

        if (Physics.Raycast(ray, out hitInfo, 999f, aimColliderLayerMask))
        {
        

            if (hitInfo.collider.gameObject.GetComponent<Zombie>() != null)
            {
                audioManager.ZombieImpactSounds();
                Instantiate(zombieHitFX, hitInfo.point, Quaternion.identity);
                hitInfo.collider.gameObject.SendMessage("TakeDamage", damage);
            }
            else
            {

                Instantiate(bulletFX, hitInfo.point, Quaternion.LookRotation(hitInfo.point));
            }
        }
    }
    public void Reload()
    {
        if (clips >= 1)
        {
            bullets = 15;
            clips--;
            canShoot = true;
        }
        Debug.Log("NEED AMMO");
    }
}
