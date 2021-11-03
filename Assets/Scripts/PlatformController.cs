using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;
  
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[1].position, platformSpeed * Time.deltaTime));
    }
}
