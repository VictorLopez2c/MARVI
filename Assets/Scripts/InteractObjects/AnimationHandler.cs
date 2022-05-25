using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    bool activeAnim;

    public void ToggleBool(string boolname)
    {
        animator.SetBool(boolname, !animator.GetBool(boolname));
    }
}
