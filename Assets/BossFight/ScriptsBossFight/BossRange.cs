using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRange : MonoBehaviour
{
    public Animator animator;
    public BossStats boss;
    public int melee;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //melee = Random.Range(0, 4);
            //switch (melee)
            //{
            //    case 0:

            //        //animator.setfloat("skills", 1f);
            //        //boss.hit_select = 0;
            //        //break;

            //    case 1:

                    animator.SetFloat("skills", 0.3f);
                    boss.hit_Select = 1;
                    //break;

                //case 2:
                //    animator.SetFloat("skills", 0);
                //    boss.hit_Select = 2;
                //    break;



            

            animator.SetBool("isAttacking", true);
            boss.isAttacking = true;
            GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
