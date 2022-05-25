using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractableModule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        if (interactable == null)
        {
            Debug.LogError("No interactable script detected!");
            return;
        }
        interactable.onInteract += Interact;
    }

    public abstract void Interact();
}
