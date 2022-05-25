using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPad : MonoBehaviour
{
    public int interactPadId;
    
    //*** Retuns the box Id for this box. Used to check to see if the correct box has been placed on the correct pad ***//
   
    public int ReturnInteractPadId()
    {
        return interactPadId;
    }
}
