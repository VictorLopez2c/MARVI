using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPuzzle : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    public int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;
    public bool KaylaOnPlatform = false;
    public bool RockOnPlatform = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KaylaFoot"))
        {
            KaylaOnPlatform = true;
            MovePlatform();
        }

        if (other.CompareTag("Rock"))
        {
            RockOnPlatform = true;
            MovePlatform();
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KaylaFoot"))
        {
            KaylaOnPlatform = false;
            nextPosition = 1;
            MovePlatform();
        }

        if (other.CompareTag("Rock"))
        {
            RockOnPlatform = false;
            nextPosition = 1;
            MovePlatform();
        }

    }
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
        

        if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;

            if (KaylaOnPlatform == false || RockOnPlatform == false)
            {
                if (KaylaOnPlatform == true)
                {
                    nextPosition = 1;

                    if (KaylaOnPlatform == false)
                    {
                        nextPosition = 1;

                    }
                }

                if (RockOnPlatform == true)
                {
                    nextPosition = 1;

                    if (RockOnPlatform == false)
                    {
                        nextPosition = 1;

                    }
                }
            }

            if (KaylaOnPlatform == true && RockOnPlatform == true)
            {
                nextPosition = 2;
            }

            if (KaylaOnPlatform == false && RockOnPlatform == false)
            {
                nextPosition = 0;
            }

            //nextPosition++;

                //if (nextPosition > platformPositions.Length - 1)
                //{
                //    nextPosition = 0;
                //}
        }
    }

    IEnumerator WaitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
