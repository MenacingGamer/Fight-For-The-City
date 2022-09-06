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
    public bool isDead;

    private LevelManager levelManager;
    private AudioManager audioManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        fist = GetComponentInChildren<ZombieFist>().gameObject;
        isDead = false;
        fist.SetActive(false);
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
 
    // Update is called once per frame
    void Update()
    {
       
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!isDead)
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
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
      //  Debug.Log(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack here
            animator.SetBool("isAttacking", true); 
          //  Debug.Log("runnnnn!!!!! im eating youuuuuuuu");

            alreadyAttacked = true;
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        animator.SetBool("isAttacking", false);
        TurnFistOFF();
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 70f || health == 50f || health == 20f) { audioManager.PlayGruntSound(); }
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Invoke(nameof(DestroyEnemy), .5f);
        }  
    }

    private void DestroyEnemy()
    {
        animator.SetBool("isDead", true);
        levelManager.ZombieCount();
        
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
