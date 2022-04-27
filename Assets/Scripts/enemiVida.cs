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
        if (Attacking == false)
        {
            currentHealth = 0;
            //AudioManager.instance.PlaySFX(deathSound);
            
            agent.speed = 0;
            agent.isStopped = true;
            Kayla.SetTrigger("Execution");
            Execution.Play();
            Task.Delay(500);
            animator.SetTrigger("Mort");
            AMort.Play();



            //Instantiate(deathEffect, transform.position, transform.rotation);
            //Instantiate(itemDrop, transform.position, transform.rotation);
        }
        if (Attacking == true)
        {
            Kayla.SetTrigger("Attack");
            currentHealth = currentHealth - 1;
            fun = fun + 1;
            //animator.SetTrigger("GetHit");
            animator.SetTrigger("GetHit");
            AHit.Play();


            if (currentHealth <= 0)
            {
                //AudioManager.instance.PlaySFX(deathSound);
                animator.SetTrigger("Mort");
                AMort.Play();
                //Enemy.GetComponent<EnemiCont>().enabled = false;
                //agent.enabled = false;
                agent.isStopped = true;
                //Instantiate(deathEffect, transform.position, transform.rotation);
                //Instantiate(itemDrop, transform.position, transform.rotation);
            }
        }

        //PlayerController.instance.Bounce();
    }

    //IEnumerator Temps()
 
   


}
