using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            other.GetComponent<enemiVida>().TakeDamage();
        }
    }
}
