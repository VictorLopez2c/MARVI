using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterial : InteractableModule
{  
    public Renderer target;
    public Material[] materials;
    int count;

    public override void Interact() { PerformInteraction(); }
    public void PerformInteraction()
    {
        count++;
        target.material = materials[count % materials.Length];
    }
    
}

