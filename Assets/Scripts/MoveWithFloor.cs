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

    void FixedUpdate()
    {

        if (Player.isGrounded)
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, Player.height / 4.2f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if (groundPosition != lastGroundPosition && groundName == lastGroundname)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                }

                lastGroundname = groundName;
                lastGroundPosition = groundPosition;
            }
        }
        else if (!Player.isGrounded)
        {
            lastGroundname = null;
            lastGroundPosition = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, Player.height /4.2f);
    }
}
