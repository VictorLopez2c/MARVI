using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTemple : MonoBehaviour
{
    public GameObject Fire;
   public Animator animator;
    public bool funciona = false;

    // Start is called before the first frame update
    void Awake()
    {
        animator.SetTrigger("Sube");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireReload")
        {
            funciona = true;
            Fire.SetActive(true);
            //animator.SetTrigger("Baja");
        }

        if (other.tag == "FireStop")
        {
            funciona = true;
            Fire.SetActive(false);
            //animator.SetTrigger("Sube");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
