using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFXController : MonoBehaviour
{
    public static PlayerFXController instance;

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
    [SerializeField] ParticleSystem _DeathEffect = default;

    [SerializeField] ParticleSystem _aRespawnParticles = default;
    [SerializeField] ParticleSystem _bRespawnParticles = default;
    [SerializeField] ParticleSystem _cRespawnParticles = default;

    [Header("SFX Sources")]

    [SerializeField] 
    private AudioClip[] _jumpFXAudios; //000//
    public AudioSource jumpAudioSource;//000//

    [SerializeField] private AudioClip[] _hitFXAudios; //000//
    public AudioSource hitAudioSource;//000//

    [SerializeField] private AudioClip[] _spawnFXAudios; //000//
    public AudioSource spawnAudioSource;//000//

    //public AudioSource _deathAudio;

    //*** VFX ***//

    // Start is called before the first frame update
    private void Start()
    {

        jumpAudioSource.playOnAwake = false;
        hitAudioSource.playOnAwake = false;

    }
    void Awake()
    {
        _slashEffect.Stop();
        _reverseSlashEffect.Stop();



        //_deathAudio.Stop();

        //_DamageEffect[sDamageFX].Stop();

        _DamageEffect.Stop(); //OK
        _DeathEffect.Stop();

        hitAudioSource = gameObject.AddComponent<AudioSource>();//000//
        jumpAudioSource = gameObject.AddComponent<AudioSource>();//000//
        spawnAudioSource = gameObject.GetComponent<AudioSource>();//000//

        _aRespawnParticles.Stop();
        _bRespawnParticles.Stop();
        _cRespawnParticles.Stop();

        instance = this;
    }

    public void EnableDeathFX()
    {
        //_deathAudio.Play();
        _DeathEffect.Play(); //OK
    }

    public void EnableRespawnFX()
    {
        _aRespawnParticles.Play();
        _bRespawnParticles.Play();
        _cRespawnParticles.Play();
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

        //AUDIO 

        hitAudioSource.volume = Random.Range(0.8f, 1);
        hitAudioSource.pitch = Random.Range(0.8f, 1.1f);


        if (_hitFXAudios.Length == 0) { print("Should play HIT, but no clip"); return; }
        int nHitAudios = Random.Range(0, _hitFXAudios.Length);
        hitAudioSource.clip = _hitFXAudios[nHitAudios];
        hitAudioSource.Play();

    }
    public void PlaySpawnFX()
    {
        _aRespawnParticles.Play();
        _bRespawnParticles.Play();
        _cRespawnParticles.Play();

        //AUDIO 
        spawnAudioSource.volume = Random.Range(0.8f, 1);
        spawnAudioSource.pitch = Random.Range(0.8f, 1.1f);

        if (_spawnFXAudios.Length == 0) { print("Should play JUMP, but no clip"); return; }
        int nSpawnAudios = Random.Range(0, _spawnFXAudios.Length);
        spawnAudioSource.clip = _spawnFXAudios[nSpawnAudios];
        spawnAudioSource.Play();
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
        //AUDIO 
        jumpAudioSource.volume = Random.Range(0.8f, 1);
        jumpAudioSource.pitch = Random.Range(0.8f, 1.1f);

        if (_jumpFXAudios.Length == 0) { print("Should play JUMP, but no clip"); return; }
        int nJumpAudios = Random.Range(0, _jumpFXAudios.Length);
        jumpAudioSource.clip = _jumpFXAudios[nJumpAudios];
        jumpAudioSource.Play();
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
