using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("DialogueCollider"))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }
}
