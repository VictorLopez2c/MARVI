using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillStil : MonoBehaviour {

    Transform player;                           //? the player ptransform;
    public Animator anim;                          //? the  Enemy Animator;
    public Transform killPosition;                  //? the transfom The player must be present in it;
    public AudioClip Choking, Bodydrop, Bodydrop2;  //? the bady sfx
    public AudioSource audioSource;


    public void SetParent()
    {
        //! Set the booling Kill true to Playe tha animatin and playe the audioClip Choking sfx;
        anim.SetBool("Kill",true);
        audioSource.PlayOneShot(Choking);
    }
    public void UnSetParent()
    {
        //! set the booling kill false
        anim.SetBool("Kill", false);
    }


    //? the function for playing body sfx When the body collides the ground;
    public void BodyDrop(int index)
    {
        switch (index)
        {
            case 1:
                audioSource.PlayOneShot(Bodydrop);
                break;
            case 2:
                audioSource.PlayOneShot(Bodydrop2);
                break;
        }
       
    }
    //! checking  if the player enter to trigger
    private void OnTriggerEnter(Collider other)
    {
        //! if player enter to trigger we Get The Stealth_KillBehaviour scrpte from the player
        if (other.tag == "Player")
        {
            //! ponemos el script del enemigo y la posición de muerte al script del jugador 
            other.GetComponent<Stealth_KillBehaviour>().Enemy = this; 
            other.GetComponent<Stealth_KillBehaviour>().KillPosition = killPosition;
            player = other.transform;
        }
    }

    //! checking  if the player Exit to trigger
    private void OnTriggerExit(Collider other)
    {

        //! if player exit the trigger ,we set the player null;
        if (other.tag == "Player")
        {
            player = null;
        }
    }
}
