using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine.Animations.Rigging;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] Rig rig;
    [SerializeField] CinemachineVirtualCamera aimCamera;
    [SerializeField] float normalSensitivity;
    [SerializeField] float aimSensitivity;
    [SerializeField] LayerMask aimColliderLayerMask;
    [SerializeField] Transform debugTransform;
    [SerializeField] Transform pfBullet;
    [SerializeField] Transform spawnBulletPosition;
    [SerializeField] Transform bulletFX;
    [SerializeField] Transform zombieHitFX;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damage;
    [SerializeField] public int ammo;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] public bool canShoot;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private AudioManager audioManager;
    private Animator animator;
    private Zombie zombie;
    private Health health;
    Vector3 mouseWorldPosition;
    Transform hitTransform;

    private void Awake()
    {
        ammo = 50;
        ammoText.text = "AMMO : " + ammo;
        health = GetComponentInChildren<Health>();
        audioManager = GetComponent<AudioManager>();
        zombie = FindObjectOfType<Zombie>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        ammoText.text = "AMMO : " + ammo;
        if  (health.playerIsDead == false && canShoot)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        else
        {
            mouseWorldPosition = ray.GetPoint(100f);
        }
             
            rig.weight = 1;
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
     

        if (starterAssetsInputs.shoot && ammo > 0)
            {
                ammo--;
                muzzleFlash.Play();
                audioManager.GunShotSound();
                if (hitTransform != null)
                {
                    if (hitTransform.GetComponent<Zombie>() != null)
                    {
                        audioManager.ZombieImpactSounds();
                        Instantiate(zombieHitFX, mouseWorldPosition, Quaternion.identity);
                        hitTransform.gameObject.SendMessage("TakeDamage", damage);
                    }
                    else
                    {

                        Instantiate(bulletFX, mouseWorldPosition, Quaternion.identity);
                    }
                }
                // Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                //Instantiate(pfBullet, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;

        }
        else if(starterAssetsInputs.shoot && ammo <= 0)
        {
            audioManager.EmptyGunSound();
        }
        starterAssetsInputs.shoot = false;
    }
}
