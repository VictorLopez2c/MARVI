using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform itemPivot;
    [SerializeField] Vector3 itemHalfSize = Vector3.one;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteract();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50.0f, Color.red);
        }
    }
    void CheckInteract()
    {
        Collider[] colliders = Physics.OverlapBox(itemPivot.position, itemHalfSize);

        //Check Collider have Interactable component
        foreach(Collider c in colliders)
        {
            Interactable interactable = c.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.Interact();
                break;
            }
        }
    }
}
