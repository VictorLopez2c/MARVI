using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invincibleLenght = 2f;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void Hurt()
    {
        if(invincCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                PlayerController.instance.Knockback();
                invincCounter = invincibleLenght;
            }

        }

    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
