using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int funciona = 0;
    public int pen = 0;
    public GameObject Tranform;
    public Transform Position;


    //
    public void Update()
    {
        
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

        if (other.CompareTag("HurtEnemy"))
        {
            if (currentEnemyInContact)
            {
                currentEnemyInContact.GetComponent<enemiVida>().EnemyTakeDamage();
                Tranform.GetComponent<Stealth_KillBehaviour>().StealthTakeDown();
                //Position = currentEnemyInContact.GetComponent<enemiVida>().EnemyTakeDamage();
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
