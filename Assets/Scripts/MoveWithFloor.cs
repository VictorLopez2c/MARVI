using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundname;


    void Start()
    {
        player = this.GetComponent<CharacterController>();

    }

    void Update()
    {

        if (player.isGrounded)
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, player.height / 4.2f, -transform.up, out hit))
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
        else if (!player.isGrounded)
        {
            lastGroundname = null;
            lastGroundPosition = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height /4.2f);
    }
}
