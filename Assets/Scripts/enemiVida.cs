using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class enemiVida : MonoBehaviour
{
    public static enemiVida instance;

    public int maxHealth = 1;
    public int currentHealth;

    //public int deathSound;
    public int fun = 0;
    public bool Attacking = false;
    public Animator animator;
    public Animator Kayla;
    public GameObject Enemy;
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioSource Execution;
    public AudioSource AMort;
    public AudioSource AHit;


    //public GameObject deathEffect, itemDrop;



    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void EnemyAttacking()
    {
        Attacking = true;
    }

    public void EnemyPatrolling()
    {
        Attacking = false;
    }

    public void EnemyTakeDamage()
    {

        if (currentHealth > 0)
        {
            int oldHealth = currentHealth;

            if (Attacking == false) { currentHealth = 0; }
            if (Attacking == true) { currentHealth = currentHealth - 1; }

            //if (currentHealth != oldHealth)
            {
                if (currentHealth <= 0)
                {
                    animator.SetTrigger("Mort");
                    AMort.Play();
                    GetComponent<EnemiCont>().enabled = false;
                    agent.isStopped = true;
                }
                else
                {
                    Kayla.SetTrigger("Attack");
                    currentHealth = currentHealth - 1;
                    fun = fun + 1;
                    animator.SetTrigger("GetHit");
                    AHit.Play();
                }
            }
        }

        //PlayerController.instance.Bounce();
    }

    //IEnumerator Temps()
 
   


}
