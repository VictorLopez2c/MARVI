using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;

    public float rotateSpeed = 5f;

    private Vector3 moveDirection;

    public CharacterController charController;
    public GameObject playerModel;
    public Camera playerCamera;

    public bool isKnocking;
    public float knockBackLenght = .5f;
    private float knockBackCounter;
    public Vector2 knockbackPower;
    

    public GameObject[] playerPieces;

    public bool stopMove;

    

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    Vector3 lastMoveDirectionOverXZ;
    void Update()
    {

        if(!isKnocking && !stopMove)
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


            if (charController.isGrounded)
            {
                moveDirection.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (moveDirectionOverXZ.sqrMagnitude > 0.01f)
            {
                lastMoveDirectionOverXZ = moveDirectionOverXZ;
            }

            //transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(lastMoveDirectionOverXZ);
            Debug.DrawRay(transform.position, lastMoveDirectionOverXZ.normalized * 5f, Color.red, 0.1f);
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            
        }

        if(isKnocking)
        {
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = (playerModel.transform.forward * knockbackPower.x);
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

    }

    public void Knockback()
    {
        isKnocking = true;
        knockBackCounter = knockBackLenght;
        Debug.Log("Knocked back");
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }
}
