using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEnable : InteractableModule
{
    [SerializeField] ParticleSystem _particleSystem = default;
    
    public AudioSource Sound;

    public void EnableParticleSystem()
    {
        _particleSystem.Play();
        Sound.Play();
    }

    public override void Interact()
    {
        EnableParticleSystem();
    }
}
