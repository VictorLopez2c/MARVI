using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class enemiVida : MonoBehaviour
{
    public static enemiVida instance;

    public int maxHealth = 1;
    public int currentHealth;

    //public int deathSound;
    public int fun = 0;
    public bool Attacking = false;
    public Animator animator;
    public Animator playerAnimator;
    //public GameObject Enemy;
    public UnityEngine.AI.NavMeshAgent agent;
    //public AudioSource playerExecutionAudioSource;
    public AudioSource AMort;
    public AudioSource AHit;


    //public GameObject deathEffect, itemDrop;

    public Transform spawnFXPos;//000//
    public GameObject spawnHitFX;//000//
    public GameObject spawnDeathFX;//000//
    [SerializeField] private AudioClip[] _hitEnemyFXAudios; //000//
    public AudioSource hitEnemyAudioSource;//000//

    [SerializeField] private AudioClip[] _tensionFXAudios; //000//
    public AudioSource tensionAudioSource;//000//

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        playerAnimator = PlayerController.instance.GetComponentInChildren<Animator>();
        //playerExecutionAudioSource = PlayerController.instance.GetComponentInChildren<AudioSource>();

        hitEnemyAudioSource = gameObject.GetComponent<AudioSource>();//000//

        tensionAudioSource = gameObject.GetComponent<AudioSource>();//000//
    }
    void Update()
    {
        
    }
    public void EnemyAttacking()
    {
        Attacking = true;

        if (currentHealth <= 0 )
        {
            DisableTensionMusic();//000//   
        }
        else {
            EnableTensionMusic();//000//
        }
    }

    public void EnemyPatrolling()
    {
        Attacking = false;
        DisableTensionMusic();//000//
    }

    public void EnemyTakeDamage()
    {

        if (currentHealth > 0)
        {
            int oldHealth = currentHealth;

            if (Attacking == false) { currentHealth = 0; }
            if (Attacking == true) { currentHealth = currentHealth - 1; playerAnimator.SetTrigger("Execution"); }

            //if (currentHealth != oldHealth)
            {
                if (currentHealth <= 0)
                {
                    animator.SetTrigger("Mort");
                    AMort.Play();
                    GetComponent<EnemiCont>().enabled = false;
                    agent.isStopped = true;
                    GetComponent<enemiVida>().enabled = false;

                    EnableDeathFX();//000//
                }
                else
                {
                    playerAnimator.SetTrigger("Attack");
                    currentHealth = currentHealth - 1;
                    fun = fun + 1;
                    animator.SetTrigger("GetHit");
                    AHit.Play();

                    EnableHitFX();//000//
                }
            }
        }

        //PlayerController.instance.Bounce();
    }

    //IEnumerator Temps()

    void EnableHitFX()//000//
    {
        hitEnemyAudioSource.volume = Random.Range(0.8f, 1);
        hitEnemyAudioSource.pitch = Random.Range(0.8f, 1.1f);


        if (_hitEnemyFXAudios.Length == 0) { print("Should play HIT, but no clip"); return; }
        int nHitAudios = Random.Range(0, _hitEnemyFXAudios.Length);
        hitEnemyAudioSource.clip = _hitEnemyFXAudios[nHitAudios];
        hitEnemyAudioSource.Play();

        Instantiate(spawnHitFX, spawnFXPos.position, spawnFXPos.rotation);
    }

    void EnableTensionMusic()
    {
        if (_tensionFXAudios.Length == 0) { print("Should play HIT, but no clip"); return; }
        int nAudios = Random.Range(0, _tensionFXAudios.Length);
        tensionAudioSource.clip = _tensionFXAudios[nAudios];
        tensionAudioSource.Play();
    }

    public void DisableTensionMusic()
    {
        tensionAudioSource.Stop();
    }
     void EnableDeathFX()
    {
        Instantiate(spawnDeathFX, spawnFXPos.position, spawnFXPos.rotation);
    }

}
