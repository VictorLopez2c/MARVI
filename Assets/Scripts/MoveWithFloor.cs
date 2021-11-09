using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController Player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundname;


    void Start()
    {
        Player = this.GetComponent<CharacterController>();

    }

    Collider currentPlatform;

    void FixedUpdate()
    {

        if (Player.isGrounded)
        {
            //RaycastHit hit;

            //if (Physics.SphereCast(transform.position, Player.height / 4.2f, -transform.up, out hit))
            //{
            //    GameObject groundedIn = hit.collider.gameObject;
            //    groundName = groundedIn.name;
            //    groundPosition = groundedIn.transform.position;

            //    if (groundPosition != lastGroundPosition && groundName == lastGroundname)
            //    {

            //        this.transform.position += groundPosition - lastGroundPosition;
            //        Player.enabled = false;
            //        Player.transform.position = this.transform.position;
            //        Player.enabled = true;
            //    }

            //    lastGroundname = groundName;
            //    lastGroundPosition = groundPosition;
            //}

            if (currentPlatform)
            {
                Vector3 platformMovement = currentPlatform.transform.position - lastGroundPosition;
                this.transform.position += platformMovement;
                lastGroundPosition = currentPlatform.transform.position;
            }
            //    lastGroundname = groundName;

        }
        else if (!Player.isGrounded)
        {
            currentPlatform = null;
            lastGroundname = null;
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

    private void OnDrawGizmos()
    {
        Player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, Player.height /4.2f);
    }
}
