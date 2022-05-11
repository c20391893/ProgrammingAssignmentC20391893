
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
private AudioSource source;
    public GameManager gm;
    Vector3 worldDeltaPosition;
    Vector2 groundDeltaPosition;
    Vector2 velocity = Vector2.zero;
    public float lookRadius = 10f;
    public PlayerManager pm;
    Transform target;
    NavMeshAgent agent;
    public float fieldOfViewAngle = 90.0f;
    private Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public CharacterStats stats;
    private float timeBetweenAttacks;
    bool alreadyAttacked;
    private bool ShouldRun;
    public bool shoulddie;
    public float Proximity, attackRange, Isaudible;
    public bool playerInProximity, playerInAttackRange, isVisible, PlayerisAudible;
    private Transform currentTarget;
    public LayerMask whatIsGround, whatIsPlayer, whatIsEnemy, Obstacle;
    public LayerMask Walkable;
    private SphereCollider col;
    bool shouldMove, shouldAttack;
    public float radius = 3;
    bool faceTarget;
    public bool ObstacleCol;
    Quaternion lookRotation;
    public EnemyStats ES;
    public GameObject HB;
    private NavMeshHit hit;
    public AudioClip MonsterClip;
    private bool playing;
    private float soundtime = 1;

    //public bool isVisible;
    // public bool isAudible;
    private void Awake()
    {
       // source = gameObject.AddComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        target = pm.player.transform;
     //  source.clip = MonsterClip;
        ConstructBehaviourTree();
    }
    public void Start()
    {
       
      //  source = gameObject.GetComponent<AudioSource>();
       // Sound();
    
        //    source.clip = MonsterClip;
        //    source.Play();
        

    }

    private void ConstructBehaviourTree()
    {
        // AttackNode attack = new AttackNode;
        //  ChaseNode chase = new ChaseNode;
        //  HealthNode health= new HealthNode;
        //   RangeNode range= new RangeNode;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        playerInProximity = Physics.CheckSphere(transform.position, Proximity, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        PlayerisAudible = Physics.CheckSphere(transform.position, Isaudible, whatIsPlayer);
        ObstacleCol = Physics.CheckSphere(transform.position, radius, Obstacle);
        isPlayerVisible();
        if (!isVisible && !playerInAttackRange) Patroling();
        // if (!playerInProximity && !playerInAttackRange) Patroling();
        if (isVisible && !playerInAttackRange) Seek();
        //if (playerInProximity && !playerInAttackRange) Seek();
        // if (playerInAttackRange && playerInProximity) Attack();
        if (playerInAttackRange && isVisible || playerInAttackRange && !isVisible) Attack();
        if (!isVisible && ES.currentHealth <= 0 || !playerInAttackRange && ES.currentHealth <= 0 || playerInAttackRange && ES.currentHealth <= 0 || isVisible && ES.currentHealth <= 0) Die();
        worldDeltaPosition = agent.nextPosition - transform.position;
        groundDeltaPosition.x = Vector3.Dot(transform.right, worldDeltaPosition);
        groundDeltaPosition.y = Vector3.Dot(transform.forward, worldDeltaPosition);
        velocity = (Time.deltaTime > 1e-5f) ? groundDeltaPosition / Time.deltaTime : velocity = Vector2.zero;
        //shouldMove = velocity.magnitude > 0.025f && agent.remainingDistance > agent.radius;

     

        //  source.Play();
    }
   

    private void Update()
    {
      //  playing = true;
        //  source = gameObject.AddComponent<AudioSource>();
        // source.clip = MonsterClip;
        //  source.clip = MonsterClip;
        // source.Play();

        Walkable = NavMesh.GetAreaFromName("Ground");
        anim.SetBool("move", shouldMove);
        anim.SetBool("die", shoulddie);
        anim.SetBool("attack", shouldAttack);
        anim.SetBool("CoolDown", alreadyAttacked);
        anim.SetBool("Run", ShouldRun);
        anim.SetFloat("velx", velocity.x);
        anim.SetFloat("vely", velocity.y);
        // Debug.Log("ShouldMove: " + shouldMove);
        // Walkable = agent.areaMask.walkable;
        timeBetweenAttacks = 1;
       

       
    }



    private void OnAnimatorMove()
    {
          transform.position = agent.nextPosition;
      //  transform.position = anim.rootPosition;
    }
    void Patroling()
    {
        agent.speed = 1;
     //  source.clip = MonsterClip;
   //     source.loop = true;
      //  source.Play();
        shouldAttack = false;
        shouldMove = true;
      
        ShouldRun = false;
        Vector3 walkpointDirection = (walkPoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(walkpointDirection.x, 0, walkpointDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);
    //    transform.LookAt(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //  Quaternion wander = Quaternion.LookRotation(walkPoint);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, wander, Time.deltaTime * 5f);
        if(ObstacleCol)
        {
         walkPointSet = false;
        }
            if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
       // source.clip = MonsterClip;

    }

    private void SearchWalkPoint()
    {
        float randomz = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f,Walkable))
        {
            walkPointSet = true;

            //  Quaternion.LookRotation(walkPoint);
            // Transform.LookAt(walkPoint);
        }
       
   //  if(NavMesh.Raycast(transform.position,walkPoint , out hit, whatIsGround))
    ///   {
      //      walkPointSet = false;
      // }
    }
    void Seek()
    {
    
        agent.speed = 3;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        shouldMove = false;
        ShouldRun = true; 
        shouldAttack = false;
      //  agent.speed = 3;
        float distance = Vector3.Distance(target.position, transform.position);

        //if (distance <= Proximity)
        //{
        agent.SetDestination(target.position);

        if (distance <= agent.stoppingDistance)
        {
            faceTarget = true;
        }
        // }
    }

    void Attack()
    {
      agent.speed = 0;
        shouldMove = false;
        shouldAttack = true;
        ShouldRun = false;
        agent.SetDestination(transform.position);
   
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        //AttackReady();
        // stats.TakeDamage(1);
        // if (!alreadyAttacked)
        //  {
        //   AttackReady();
        //  shouldAttack = true;
        //  stats.TakeDamage(10);
        //  alreadyAttacked = true;
        //  shouldAttack = true;
        //  Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //}
    }
    void AttackReady()
    {
       
        if (playerInAttackRange)
        {
            stats.TakeDamage(10);
         //   shouldAttack = false;
        }
     //   shouldAttack = false;
    }

    public void Test()
    {
       // if (playerInAttackRange)
      //  {
            CoolDown();
      //  }
    }
    public void CoolDown()
    {
       // if(playerInAttackRange)
      //  {
          //  shouldAttack = false;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
       // }
      
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        //shouldAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Proximity);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Isaudible);

        //Gizmos.color = Color.white;
        // Gizmos.DrawWireSphere(transform.position, radius);


    }

    public void isPlayerVisible()
    {




        Vector3 direction = target.transform.position - transform.position;
        // float distance = Vector3.Distance(target.position, transform.position);
        float angle = Vector3.Angle(direction, transform.forward);

        // Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        //  Gizmos.color = Color.green;
        //  Gizmos.DrawWireSphere(transform.position, angle);
        NavMeshHit hit;


        if (!agent.Raycast(target.position, out hit) && angle < fieldOfViewAngle * 0.5f && PlayerisAudible == true)
        {




            Debug.Log("Seek");
            isVisible = true;

        }
        else
        {

            Debug.Log("Player is NOT VISIBLE");
            isVisible = false;

        }


    }

    public void Die()
    {
      
        //  gm.gameStatus.score= gm.gameStatus.score +10;
        shoulddie = true;
        
            HB.SetActive(false);
            agent.SetDestination(transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        // gm.score += 10;
    }

    public void DeathSound()
    {
        FindObjectOfType<MonsterAudioManager>().Play("MonsterDeath");
    }

       
      
    

    public void Destroy()
    {
        gm.gameStatus.score += 10;
        gm.gameStatus.enemyCount += 1;
        Destroy(gameObject);
    }
}