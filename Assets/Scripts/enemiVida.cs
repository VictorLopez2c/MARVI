using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiVida : MonoBehaviour
{
    public static enemiVida instance;

    public int maxHealth = 1;
    public int currentHealth;

    //public int deathSound;
    public int fun = 0;
    public bool Attacking = false;

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
            Destroy(gameObject);

            //Instantiate(deathEffect, transform.position, transform.rotation);
            //Instantiate(itemDrop, transform.position, transform.rotation);
        }
        if (Attacking == true)
        {
            currentHealth = currentHealth - 1;
            fun = fun + 1;
            if (currentHealth <= 0)
            {
                //AudioManager.instance.PlaySFX(deathSound);
                Destroy(gameObject);

                //Instantiate(deathEffect, transform.position, transform.rotation);
                //Instantiate(itemDrop, transform.position, transform.rotation);
            }
        }

        //PlayerController.instance.Bounce();
    }


}
