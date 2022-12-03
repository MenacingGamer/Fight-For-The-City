using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
   
     private Transform player;
     private Animator animator;
   

    [SerializeField] public LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] private GameObject fist;
    [SerializeField] public float health = 100f;
   
    //patroling
    [SerializeField] public Vector3 walkPoint;
    [SerializeField] bool walkPointSet;
    [SerializeField] public float walkPointRange;

    //Attacking
    [SerializeField] public float timeBetweenAttacks;
    [SerializeField] bool alreadyAttacked;

    //States
    [SerializeField] public bool playerInSightRange, playerInAttackRange;
    [SerializeField] public float sightRange, attackRange;
    [SerializeField] public GameObject[] skins;
    [SerializeField] private GameObject currentSkin;
    [SerializeField] private GameObject newSkin;


    public bool isDead;

    private LevelManager levelManager;
    private AudioManager audioManager;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        newSkin = skins[Random.Range(0, skins.Length)];
        currentSkin.SetActive(false);
        newSkin.SetActive(true);
        levelManager = FindObjectOfType<LevelManager>();
        fist = GetComponentInChildren<ZombieFist>().gameObject;
        isDead = false;
        fist.SetActive(false);
        animator = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        agent = GetComponent<NavMeshAgent>();
        audioManager = FindObjectOfType<AudioManager>();
        if (levelManager.state == LevelManager.State.endGame) { return; }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
       
    }
 
    // Update is called once per frame
    void Update()
    {
        if (levelManager.state == LevelManager.State.endGame) { return; }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!isDead)
        {
            if (!playerInAttackRange) ChasePlayer();

            if (playerInAttackRange && player.position.y < 2f) AttackPlayer();

        
        }
      

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
    
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);     
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
    
        if (!alreadyAttacked)
        {
            //Attack here

            alreadyAttacked = true;
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

  
    private void ResetAttack()
    {
        TurnFistOFF();
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 65f || health == 30f) { audioManager.PlayGruntSound(); }
        if (health <= 0 && !isDead)
        {
            audioManager.ZombieEndSound();
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
            isDead = true;
            animator.SetBool("isDead", true);
            levelManager.ZombieCount();
            Invoke(nameof(DestroyEnemy), 15f);
        }  
    }

    private void DestroyEnemy()
    {
        
       Destroy(gameObject);
        
    }


    public void TurnFistOn()
    {
        fist.SetActive(true);
    }


    public void TurnFistOFF()
    {
        fist.SetActive(false);
    }

  
}
