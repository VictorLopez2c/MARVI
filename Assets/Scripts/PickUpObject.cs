using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    private GameObject PickedObject;
    private Transform interactionZone;

    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        
            if (Input.GetKeyDown(KeyCode.E))
        {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
