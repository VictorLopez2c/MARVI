using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzleCanvas : MonoBehaviour
{
    [SerializeField] private Animator _Animator = null;
    public AudioSource Sound;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
        }
    }
    private void OnTriggerStay(Collider collider)
    {
                
        if(collider.gameObject.tag == "Player")
        {
            _Animator.SetBool("Open", true);
            Sound.Play();
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            _Animator.SetBool("Open", false);
        }            
    }
}
