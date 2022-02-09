using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiVida : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    public int deathSound;

    public GameObject deathEffect, itemDrop;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            //AudioManager.instance.PlaySFX(deathSound);
            Destroy(gameObject);

            Instantiate(deathEffect, transform.position, transform.rotation);
            Instantiate(itemDrop, transform.position, transform.rotation);
        }

        //PlayerController.instance.Bounce();
    }
}
