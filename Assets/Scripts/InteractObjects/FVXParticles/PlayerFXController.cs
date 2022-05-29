using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFXController : MonoBehaviour
{
    

    //*** VFX ***//
    [Header("VFX Sources")]
    [SerializeField] ParticleSystem _walkingParticles = default;
    [SerializeField] ParticleSystem _landParticles = default;
    [SerializeField] ParticleSystem _jumpParticles = default;

    [SerializeField] ParticleSystem _slashEffect = default;
    [SerializeField] ParticleSystem _reverseSlashEffect = default;

    [Header("VFX Damage Sources")]
    //public Transform postionContainerVXF;

    //public GameObject[] instantiateDamageVXF;
    //[SerializeField] List<ParticleSystem> _DamageEffect = default;
    
    [SerializeField] ParticleSystem _DamageEffect = default; //OK

    [Header("SFX Sources")]
    public AudioSource _jumpAudio;
    public AudioSource _hitAudio;
    public AudioSource _deathAudio;

    //*** VFX ***//

    // Start is called before the first frame update
    void Awake()
    {
        _slashEffect.Stop();
        _reverseSlashEffect.Stop();


        _jumpAudio.Stop();
                
        //_DamageEffect[sDamageFX].Stop();

        _DamageEffect.Stop(); //OK
    }


    public void EnableDamageFX()
    {
        //int nDamageFX = Random.Range(0, instantiateDamageVXF.Length);
        //instantiateDamageVXF[nDamageFX] = Instantiate(instantiateDamageVXF[nDamageFX], postionContainerVXF.position, instantiateDamageVXF[nDamageFX].transform.rotation) as GameObject;
        //Destroy(instantiateDamageVXF[nDamageFX], 5);//**

        //damageFXSwitching.SwitchDamage();

        //nDamageFX = Random.Range(0, _DamageEffect.Count);
        //_DamageEffect[nDamageFX].Play();

        _DamageEffect.Play();//OK
        _hitAudio.Play();
    }


    public void EnableWalkParticles()
    {
        _walkingParticles.Play();
    }

    public void DisableWalkParticles()
    {
        _walkingParticles.Stop();
    }

    public void PlayJumpParticles()
    {
        _jumpParticles.Play();
        _jumpAudio.Play();
    }
    public void PlayLandParticles()
    {
        _landParticles.Play();
    }

    public void PlaySlashEffect()
    {
        _slashEffect.Play();
    }

    public void PlayReverseSlashEffect()
    {
        _reverseSlashEffect.Play();
    }

    public void PlayLandParticles(float intensity)
    {
        // make sure intensity is always between 0 and 1
        intensity = Mathf.Clamp01(intensity);

        ParticleSystem.MainModule main = _landParticles.main;
        ParticleSystem.MinMaxCurve origCurve = main.startSize; //save original curve to be assigned back to particle system
        ParticleSystem.MinMaxCurve newCurve = main.startSize; //Make a new minMax curve and make our changes to the new copy

        float minSize = newCurve.constantMin;
        float maxSize = newCurve.constantMax;

        // use the intensity to change the maximum size of the particle curve
        newCurve.constantMax = Mathf.Lerp(minSize, maxSize, intensity);
        main.startSize = newCurve;

        _landParticles.Play();

        // Put the original startSize back where you found it
        StartCoroutine(ResetMinMaxCurve(_landParticles, origCurve));

        // Note: We don't necessarily need to reset the curve, as it will be overridden
    }

    private IEnumerator ResetMinMaxCurve(ParticleSystem ps, ParticleSystem.MinMaxCurve curve)
    {
        while (ps.isEmitting)
        {
            yield return null;
        }

        ParticleSystem.MainModule main = ps.main;
        main.startSize = curve;
    }
}
