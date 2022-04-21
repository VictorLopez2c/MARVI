using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_KillBehaviour : MonoBehaviour
{

	// Use this for initialization
    public KillStil _Enemy;             //? killstill Scripte;
    public Transform KillPosition;      //? the transfom The player must be present in it;
    public float time;                  //? the Coroutine Time;
    public Animator anim;  

    public KillStil Enemy
    {
        get { return _Enemy; }
        set { _Enemy = value; }
    }
    
	void Start () {
        //! Subscribe and register this behaviour as  behaviour.
       anim=this.GetComponent<Animator>();
	}

    // Update is called once per frame
    public void StealthTakeDown()
    {

          //! Cambia posicion y rotacion 
            this.transform.position = KillPosition.position;
            this.transform.rotation = KillPosition.rotation;

            //! verifica si la posicion y rotacion cambio
            if(this.transform.position == KillPosition.position && this.transform.rotation == KillPosition.rotation)
            {
               
                
                //! playe animation Kill
                anim.SetTrigger("Kill");
                _Enemy.SetParent();

                //! start the coroutine 
                StartCoroutine(EndKillStealth());
            }
       
	}

    
    IEnumerator EndKillStealth()
    {
        //Duracion Animacion
        yield return new WaitForSeconds(time);
       

        //! set the enemy  and the kill position equle null
        _Enemy = null;
        KillPosition=null;
    }
}

