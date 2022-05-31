using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    Animator animator;
    public static PuzzleDoor instance;


     void Awake()
    {
        instance = this;
    }

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }
}
