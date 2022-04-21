using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemiga : MonoBehaviour
{

    public bool vision = false;
    public EnemiCont rango;
    public int antonio = 0;

    // Start is called before the first frame update
    void Start()
    {
        rango = GameObject.Find("Enemy").GetComponent<EnemiCont>();
    }

    // Update is called once per frame
    public void Update(Collider other)
    {

        if (rango != null) rango = GameObject.Find("Enemy").GetComponent<EnemiCont>();

        if (rango.cerca == false)
        {
            vision = false;
        }

        if (currentEnemyInContact)
        {
            currentEnemyInContact.GetComponent<enemiVida>().EnemyAttacking();
        }

        if (other.tag == "Player")
        {
            vision = true;
        }
    }

    EnemiCont currentEnemyInContact = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            antonio = 1;

            vision = true;
        }

        if (other.CompareTag("Player"))
        {
            EnemiCont enemiCont = GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = enemiCont;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            vision = false;
        }
        if (other.CompareTag("Player"))
        {
            EnemiCont enemiCont = GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             PlayerController enemiCont = other.GetComponentInParent<PlayerController>();

             if (enemiCont)
             {
                 currentEnemyInContact = enemiCont;
             }
         }
     }

     private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             PlayerController enemiCont = other.GetComponentInParent<PlayerController>();

             if (enemiCont)
             {
                 currentEnemyInContact = null;
             }
         }
     }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            antonio = 1;
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = enemiCont;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }*/
}
