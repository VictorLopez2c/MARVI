using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemiga : MonoBehaviour
{

    public bool vision = false;
    EnemiCont enemiCont;

    // Start is called before the first frame update

    private void Awake()
    {
        enemiCont = GetComponentInParent<EnemiCont>();
    }
    public void Update(Collider other)
    {
        if (enemiCont.cerca == false)
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
            vision = true;
        }

        if (other.CompareTag("Player"))
        {
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
            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }
}
