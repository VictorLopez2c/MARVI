using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiCont : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    
    public UnityEngine.AI.NavMeshAgent agent;


    public float waitAtPoint = 2f;
    private float waitCounter;

    public float chaseRange;

    public float PlayerRange;

    public float attackRange = 1f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;
    public bool TeVeo = false;
    public bool TeSiento = false;
    public bool cerca = false;

    public Animator animator;
    //public PlayerController variable correr;


    public PlayerController putasoHit;
    public int _DaNo = 0;
    //private List<PlayerController> PlayerList;

    public VisionEnemiga see;

    public AudioSource BattleOn;

    public enum AIState
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking
    };
    public AIState currentState;

    void Start()
    {
        waitCounter = waitAtPoint;
        putasoHit = GameObject.Find("Player").GetComponent<PlayerController>();
        see = GameObject.Find("Vista").GetComponent<VisionEnemiga>();
        //variable correr = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public void Update()
    {
        //PlayerController PlayerScript = GetComponent<PlayerController>();
        //PlayerController variable = GetComponent<PlayerController>();
        //putasohit = variable.putaso;
        if (putasoHit != null) putasoHit = GameObject.Find("Player").GetComponent<PlayerController>();
        if (see != null) see = GameObject.Find("Vista").GetComponent<VisionEnemiga>();
        //if (variable correr != null) variable correr = GameObject.Find("Player").GetComponent<PlayerController>();


        if (putasoHit != null && putasoHit.putaso == true)
        {
            _DaNo = 1;
        }


        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        if (distanceToPlayer <= PlayerRange)
        {
            TeSiento = true;
        }

        switch (currentState)
        {
            case AIState.Idle:
                animator.SetBool("IsMoving", false);
                animator.SetBool("IsChasing", false);
                cerca = false;
                TeVeo = false;

                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.Patrolling;
                    agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }

                if ((see.vision == true) && (distanceToPlayer < chaseRange))
                {
                    currentState = AIState.Chasing;
                    animator.SetBool("IsMoving", true);
                    cerca = true;
                    TeVeo = true;
                }

                break;

            case AIState.Patrolling:

                //agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                agent.speed = 1;

                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length) //Cambiar Num por numero de Point Patrolls
                    {
                        currentPatrolPoint = 0;
                    }

                    //agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;
                }

                if ((see.vision == true) && (distanceToPlayer < chaseRange))
                {
                    currentState = AIState.Chasing;
                    cerca = true;
                    TeVeo = true;
                }

                //Deteccion al correr

                /*else if ("variable correr == true" && distanceToPlayer < attackRange)
                {
                    currentState = AIState.Chasing;
                }*/

                animator.SetBool("IsMoving", true);

                break;

            case AIState.Chasing:

                agent.SetDestination(PlayerController.instance.transform.position);
                agent.speed = 4;
                animator.SetBool("IsChasing", true);
                //BattleOn?.Play();

                if (distanceToPlayer <= attackRange) // para hacer un rango (distanceToPlayer < attackRange)
                {
                    agent.speed = 0;
                    currentState = AIState.Attacking;
                    animator.SetTrigger("Attack");
                    animator.SetBool("IsMoving", false);
                    animator.SetBool("IsChasing", false);

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;

                    attackCounter = timeBetweenAttacks;
                }

                if (distanceToPlayer > chaseRange)
                {
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;

                    agent.velocity = Vector3.zero;
                    agent.SetDestination(transform.position);
                }

                break;

            case AIState.Attacking:

                transform.LookAt(PlayerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    if (distanceToPlayer < attackRange)
                    {
                        agent.speed = 0;
                        animator.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;
                        TeVeo = true;
                        agent.enabled = false;
                    }
                    else
                    {
                        currentState = AIState.Idle;
                        waitCounter = waitAtPoint;

                        agent.isStopped = false;


                    }

                    if (distanceToPlayer < 5)
                    {
                        agent.speed = 0;
                    }

                }

                break;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            //GameManager.instance.AddGold(value);

            //Destroy(gameObject);

        }
    }*/
}

