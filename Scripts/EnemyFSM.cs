using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;

    public Sight sightSensor;

    Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;

    NavMeshAgent agent;
    Animator animator;

    public GameObject bulletPreFab;
    public float fireRate;
    public float lastShootTime;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        baseTransform = GameObject.Find("BaseTest").transform;
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == EnemyState.GoToBase)
            GotToBase();
        else if (currentState == EnemyState.AttackBase)
            AttackBase();
        else if (currentState == EnemyState.ChasePlayer)
            ChasePlayer();
        else if (currentState == EnemyState.AttackPlayer)
            AttackPlayer();

    }

    void GotToBase() {
        animator.SetBool("Shooting", false);
        print("GoToBase");
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase <= baseAttackDistance)
            currentState = EnemyState.AttackBase;
    }
    void AttackBase() {

        agent.isStopped = true;
        print("AttackBase");
        LookTo(baseTransform.position);
        Shoot();
  
    }
    void ChasePlayer() {
        animator.SetBool("Shooting", false);
        print("ChasePlayer");

        agent.isStopped = false;

        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance)
            currentState = EnemyState.AttackPlayer;
           
    }
    void AttackPlayer() {
        print("AttackPlayer");

        agent.isStopped = true;

        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f)
            currentState = EnemyState.ChasePlayer;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    void Shoot()
    {
        animator.SetBool("Shooting", true);

        if(Time.timeScale > 0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
                return;
            lastShootTime = Time.time;
            Instantiate(bulletPreFab, transform.position, transform.rotation);
        }
    }

    void LookTo(Vector3 targetPostion)
    {
        Vector3 directionToPostion = Vector3.Normalize(targetPostion - transform.parent.position);
        directionToPostion.y = 0;
        transform.parent.forward = directionToPostion;
    }

}
