using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{


    public int damage;
    //public HealthManager health;



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager.instance.Hurt();
        }
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
