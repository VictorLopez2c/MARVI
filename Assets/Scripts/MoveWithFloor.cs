using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController Player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;


    void Start()
    {
        Player = this.GetComponent<CharacterController>();

    }

    Collider currentPlatform;

    void FixedUpdate()
    {

        if (Player.isGrounded)
        {

            if (currentPlatform)
            {
                Vector3 platformMovement = currentPlatform.transform.position - lastGroundPosition;
                this.transform.position += platformMovement;
                lastGroundPosition = currentPlatform.transform.position;
            }

        }
        else if (!Player.isGrounded)
        {
            currentPlatform = null;
            lastGroundPosition = Vector3.zero;
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("MovingPlatform"))
        {
            Debug.Log("OnControllerColliderHit");
            if (currentPlatform != hit.collider)
            {
                currentPlatform = hit.collider;
                lastGroundPosition = currentPlatform.transform.position;
            }
        }
    }
}
