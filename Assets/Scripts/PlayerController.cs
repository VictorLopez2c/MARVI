 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public PlayerController controller;

    //*** FX Player Controller***//
    PlayerFXController playerFXController;

    [Header("Player Characteristics")]
    public bool Still;
    public float moveSpeed;
    public float jumpForce;
    public bool pepino = false;
    public float gravityScale = 5f;

    public float rotateSpeed = 5f;

    private Vector3 moveDirection;

    [Header("Player Sources")]
    public CharacterController charController;
    public Animator animator;

    public GameObject playerModel;
    public Camera playerCamera;

    public GameObject[] playerPieces;

    [Header("Player States")]
    public bool isKnocking;
    public float knockBackLenght = .5f;
    private float knockBackCounter;
    public Vector2 knockbackPower;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    public bool stopMove;

    public bool AttackArea = false;

    public int poo = 0;
    //public MeVes;
    //public EnemiCont MeSientes;
    public bool canStealthKill = false; //variable para definir ataque ligero(true) o ataque mortal(false)

    public bool putaso = false;
    public EnemiCont destruir;

    Vector3 lastPosition;


    private void Awake()
    {
        instance = this;
        lastPosition = transform.position;
    }


    void Start()
    {
        charController = GetComponent<CharacterController>();
        //MeVes = GameObject.Find("Enemy").GetComponent<EnemiCont>();
        //MeSientes = GameObject.Find("Enemy").GetComponent<EnemiCont>();

        playerFXController = GetComponentInChildren<PlayerFXController>();  //*** FX Player Controller***//
        
    }

    /*IEnumerator ExampleCaoroutine()
    {
        yield return new WaitForSeconds(2);

        groundedF();
    }

    public void groundedF()
    {
        if (charController.isGrounded != true)
        {
            animator.SetBool("Fall", true);
        }
    }*/
   

Vector3 lastMoveDirectionOverXZ;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 8"))
        {
            animator.SetBool("Run", true);
            moveSpeed = 6;
            Still = false;
            playerFXController.EnableWalkParticles(); //*** VFX *** WALK DISABLE //
            //stopMove = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 9"))
        {
            moveSpeed = 2;
            animator.SetBool("Run", false);
            playerFXController.DisableWalkParticles(); //*** VFX *** WALK DISABLE //
        }





        canStealthKill = false;
        if (currentEnemyInContact)
        {
            if (currentEnemyInContact.TeSiento == true && currentEnemyInContact.TeVeo == false)
            {
                canStealthKill = false;
            }
            if (currentEnemyInContact.TeVeo == false && currentEnemyInContact.TeSiento == false)
            {
                canStealthKill = true;
            }

            if (currentEnemyInContact != null && currentEnemyInContact.TeVeo == true)
            { //Pasa a combate ligero

                canStealthKill = true;
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 2")
)
        {
            putaso = true;
            //aqui ejecutar animacion de ataque

            animator.SetTrigger("Attack");
            //stopMove = true;

            if (currentEnemyInContact)
            {
                poo = poo + 1;
                //currentEnemyInContact.GetComponent<enemiVida>().EnemyTakeDamage();
            }
        }

        if (!isKnocking && !stopMove)
        {
            float yStore = moveDirection.y;

            Vector3 moveDirectionOverXZ = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            Camera camera = Camera.main;
            moveDirectionOverXZ = camera.transform.TransformDirection(moveDirectionOverXZ);
            moveDirectionOverXZ = Vector3.ProjectOnPlane(moveDirectionOverXZ, Vector3.up);

            Debug.DrawRay(transform.position, moveDirectionOverXZ.normalized * 5f, Color.green, 0.1f);

            moveDirection = moveDirectionOverXZ;

            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;

            moveDirection.y = yStore;
            

            if (transform.hasChanged)
            {
                animator.SetBool("isWalking", true);
                transform.hasChanged = false;
            }
            else
            {
                animator.SetBool("isWalking", false);
                Still = true;
            }

            if (charController.isGrounded)
            {
                moveDirection.y = 0f;
                SlideDown();
                animator.SetBool("Fall", false);

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                    animator.SetTrigger("Jump");

                    playerFXController.DisableWalkParticles();    //*** VFX *** WALK DISABLE //
                    playerFXController.PlayJumpParticles(); //*** VFX *** LAND//
                }

                
            }
            if (charController.isGrounded != true)
            {

            }
                

          

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (moveDirectionOverXZ.sqrMagnitude > 0.01f)
            {
                lastMoveDirectionOverXZ = moveDirectionOverXZ;
            }

            Quaternion newRotation = Quaternion.LookRotation(lastMoveDirectionOverXZ);
            Debug.DrawRay(transform.position, lastMoveDirectionOverXZ.normalized * 5f, Color.red, 0.1f);
            //playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }

        if(isKnocking)
        {
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            //moveDirection = (playerModel.transform.forward * knockbackPower.x);
            moveDirection = (transform.forward * knockbackPower.x);
            moveDirection.y = yStore;

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);


            if (knockBackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        if (stopMove)
        {
            moveDirection = Vector3.zero;
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            charController.Move(moveDirection);

           
        }

        if (Still == true)
        {
            moveSpeed = 4;
            playerFXController.DisableWalkParticles(); //*** VFX *** WALK DISABLE //

        }

        Vector3 movementInThisFrame = transform.position - lastPosition;
        animator.SetFloat("Speed", movementInThisFrame.magnitude / Time.deltaTime);

        lastPosition = transform.position;

    }


    public void Knockback()
    {
        isKnocking = true;
        knockBackCounter = knockBackLenght;
        Debug.Log("Knocked back");
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
        playerFXController.EnableDamageFX();
    }

    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= charController.slopeLimit;
        
        if (isOnSlope)
        {
            animator.SetBool("Fall", true);
            moveDirection.x += ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
            moveDirection.z += ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;

            moveDirection.y += slopeForceDown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
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

     public void Area()
    {
        AttackArea = true;
    }



    /*public void StealthTakeDown()
    {

        //! change the position and rotation of the player
        this.transform.position = KillPosition.position;
        this.transform.rotation = KillPosition.rotation;

        //! checking  if the position and rotation of the player is change it;
        if (this.transform.position == KillPosition.position && this.transform.rotation == KillPosition.rotation)
        {

            //! playe animation Kill
            anim.SetTrigger("Kill");
            _Enemy.SetParent();

            //! start the coroutine 
            StartCoroutine(EndKillStealth());
        }
    }*/


}
