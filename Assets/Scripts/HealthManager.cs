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
        UIManager.instance.hurtImage.enabled = false;//Hurt IMG- Canvas Disabled

    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;


            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if (Mathf.Floor(invincCounter * 5f) % 2 == 0)
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
        if (invincCounter <= 0)
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
                StartCoroutine(HurtImageCanvas());//Hurt IMG- Canvas Effect
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
        if (UIManager.instance.healthText != null)
        {
            UIManager.instance.healthText.text = currentHealth.ToString();
        }
        CircleHealtBar();//Apply Healt Bar - Canvas Effect

    }

    void CircleHealtBar()//Circle Healt Bar - Canvas Effect
    {
        float helathPercentage = (float)currentHealth / (float)maxHealth;//HelathPercentage of currentHealt
        UIManager.instance.healthImage.fillAmount = helathPercentage;
    }

    private IEnumerator HurtImageCanvas()
    {
        UIManager.instance.hurtImage.enabled = !UIManager.instance.hurtImage.enabled;//first code executed 
        yield return new WaitForSeconds(0.5f); //code DELAY
        UIManager.instance.hurtImage.enabled = !UIManager.instance.hurtImage.enabled;//code resumes after DELAY and exits if there is nothing else to run
    }
}
