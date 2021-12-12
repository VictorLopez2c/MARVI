using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invincibleLenght = 2f;
    private float invincCounter;

    public AudioSource hitSound;
    public AudioSource deathSound;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;


            for(int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }

                if (invincCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
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
                deathSound.Play();
            }
            else
            {
                PlayerController.instance.Knockback();
                invincCounter = invincibleLenght;
                hitSound.Play();
            }

        }

        UpdateUI();

    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void AddHealth(int amountToHeal)
    {
        currentHealth += amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        UIManager.instance.healthText.text = currentHealth.ToString();
    }
}
