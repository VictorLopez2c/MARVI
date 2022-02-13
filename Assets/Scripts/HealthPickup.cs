using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public bool isFullHealth;
    public AudioSource healthSound;
    public GameObject healthEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthSound.Play();
            Destroy(gameObject);
            Instantiate(healthEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

            if(isFullHealth)
            {
                HealthManager.instance.ResetHealth();
            }
            else
            {
                HealthManager.instance.AddHealth(healAmount);
            }
        }
    }

}
