using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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
            Kayla.SetTrigger("Execution");
            Thread.Sleep(500);



            //Instantiate(deathEffect, transform.position, transform.rotation);
            //Instantiate(itemDrop, transform.position, transform.rotation);
        }
        if (Attacking == true)
        {
            currentHealth = currentHealth - 1;
            fun = fun + 1;
            //animator.SetTrigger("GetHit");
            animator.SetTrigger("GetHit");

            if (currentHealth <= 0)
            {
                //AudioManager.instance.PlaySFX(deathSound);
                animator.SetTrigger("Mort");
                //Enemy.GetComponent<EnemiCont>().enabled = false;
                //agent.enabled = false;
                agent.isStopped = true;
                //Instantiate(deathEffect, transform.position, transform.rotation);
                //Instantiate(itemDrop, transform.position, transform.rotation);
            }
        }

        //PlayerController.instance.Bounce();
    }

    IEnumerator Temps()
    {

    }
   


}
