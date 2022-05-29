using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BossStats : MonoBehaviour
{

    
    public Animator animator;

    public int bossMaxHealth;
    public int bossCurrentHealth;
    public float crono;
    public int rutine;
    public float rutineTime;

    public Quaternion Angle;
    public float degree;

    public BossRange range;
    public GameObject target;

    public bool isAttacking;
    public bool isDeath;

    public AudioSource bossMusic;

    public GameObject[] hit;
    public int hit_Select;



    ///FlameThrower///

    public bool flame_thrower;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject FT_emitter;
    public GameObject firePS;
    private float crono2;

    ///Fire Ball///


    public GameObject fire_ball;
    public GameObject FB_emitter;
    public List<GameObject> pool2 = new List<GameObject>();

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {

        target = GameObject.Find("Player");


    }


    public void Boss_Behaviour()
    {
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        FB_emitter.transform.LookAt(target.transform.position);
        bossMusic.enabled = true;



        if (Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
        {
            
            switch (rutine)
            {

                case 0: //Channeling

                    animator.SetBool("isAttacking", false);
                    animator.SetFloat("skills", 0f);


                    crono += 2 * Time.deltaTime;
                    if (crono > rutineTime)
                    {
                        rutine = Random.Range(0, 3);
                        crono = 0;
                    }

                    break;

                case 1: //FlameThrower

                    animator.SetBool("isAttacking", true);
                    animator.SetFloat("skills", 0.6f);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                    range.GetComponent<CapsuleCollider>().enabled = false; //Poner trigger en prefab ded Boss

                    break;

                case 2: //Fire ball


                    animator.SetBool("isAttacking", true);
                    animator.SetFloat("skills", 1f);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                    range.GetComponent<CapsuleCollider>().enabled = false;

                    


                    break;



            }


        }

    }



public void End_Animation()
{

    rutine = 0;
    animator.SetBool("isAttacking", false); //modificar y añadir anims del xaman
    isAttacking = false;
    range.GetComponent<CapsuleCollider>().enabled = true;
    flame_thrower = false;

}

        



public void ColliderWeaponTrue()
{
    hit[hit_Select=0].GetComponent<CapsuleCollider>().enabled = true;
}

        
public void ColliderWeaponFalse()
{

    hit[hit_Select=0].GetComponent<CapsuleCollider>().enabled = false;

}


///FlameThrower///
public GameObject GetFlame()
{
    for (int i = 0; i < pool.Count; i++)
    {
        if (!pool[i].activeInHierarchy)
        {
            pool[i].SetActive(true);
            return pool[i];
        }
    }
    GameObject obj = Instantiate(fire,FT_emitter.transform.position,FT_emitter.transform.rotation) as GameObject;
    pool.Add(obj);
    return obj;
}

        
public void FlameThrower_Skill()
{
    crono2 += 1 * Time.deltaTime;
    if (crono2 > 0.1f)
    {
        GameObject obj = GetFlame();
        obj.transform.position = FT_emitter.transform.position;
        obj.transform.rotation = FT_emitter.transform.rotation;
        crono2 = 0;
    }
}

public void Start_Fire()
{
    flame_thrower = true;
    firePS.SetActive(true);
    
}
        
public void Stop_Fire()
{
    flame_thrower = false;
    firePS.SetActive(false);
}

///FireBall///

public GameObject Get_Fire_Ball()
{
    for (int i = 0; i < pool2.Count; i++)
    {
        if (!pool2[i].activeInHierarchy)
        {
            pool2[i].SetActive(true);
            return pool2[i];
        }
    }
    GameObject obj = Instantiate(fire_ball, FB_emitter.transform.position, FB_emitter.transform.rotation) as GameObject;
    pool2.Add(obj);
    return obj;

}

public void Fire_ball_Skill()
{
    GameObject obj = Get_Fire_Ball();
    obj.transform.position = FB_emitter.transform.position;
    obj.transform.rotation = FB_emitter.transform.rotation;
}


public void Alive()
{
    //if (bosscurrenthealth < 10)
    //{
    //    bossphase = 2;
    //    phasetime = 1;
    //}

    Boss_Behaviour();

    if (flame_thrower)
    {
        FlameThrower_Skill();
    }

}

//public void TakeDamage()
//{
//    bossCurrentHealth = bossCurrentHealth - 1;
//    animator.Play("BossHit");

//    if (bossCurrentHealth <= 0)
//    {
//        bossCurrentHealth = 0;
//        animator.Play("BossDeath");
//        isDeath = true;
//    }
//}





private void Update()
{
    if (bossCurrentHealth > 0)
    {
        Alive();
    }
    else
    {
        if (!isDeath)
        {
            animator.SetTrigger("Dead");
            bossMusic.enabled = false;
            isDeath = true;
            StartCoroutine(GameManager.instance.LevelEndWaiter());
        }
    }
}

}
