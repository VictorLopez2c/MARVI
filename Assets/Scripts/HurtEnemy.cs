using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int funciona = 0;
    public int pen = 0;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            if (currentEnemyInContact)
            {
                currentEnemyInContact.GetComponent<enemiVida>().EnemyTakeDamage();
            }
        }
    }

    EnemiCont currentEnemyInContact = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = enemiCont;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Enemy")
        {
            funciona = funciona + 1;
            PlayerController.instance.Area();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Enemy")
        {
            pen = pen + 1;
            PlayerController.instance.Area();

        }
    }*/
}
