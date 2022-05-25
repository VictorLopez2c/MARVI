using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public Action onInteract;

    public void Interact()
    {
        Debug.Log("Int" + gameObject.name);
        onInteract?.Invoke();
        if (onInteract == null)
        {
            Debug.LogWarning("No onInteract methods were linked to this Interactable.");
        }
    }
}
