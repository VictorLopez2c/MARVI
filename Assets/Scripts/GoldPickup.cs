using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{

    public int value;

    public GameObject goldEffect;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddGold(value);
            Destroy(gameObject);
            Instantiate(goldEffect, transform.position, transform.rotation);
        }
    }
}