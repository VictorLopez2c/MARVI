using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OroSettings : MonoBehaviour
{
    public static OroSettings audioSettings;

    //[Header("Information - Read Only from inspector")]
    [SerializeField]
    private float musicVolume;
    [SerializeField]
    private float sfxVolume;
    [SerializeField]
    private int robotVolume = 1;
    [SerializeField]
    private int olisboVolume = 2;
    [SerializeField]
    private int calaveraVolume = 3;
    [SerializeField]
    private int discoVolume = 4;

    float musicDefaultVolume=0.7f;
    float sfxDefaultVolume = 0.9f;
    public GameObject FxBase;

    //string musicAudioSourcesTag ="Music-AudioSource";
    //string sfxAudioSourcesTag="SFX-AudioSource";

    string musicVolumeDataName = "music-volume";
    string sfxVolumeDataName = "sfx-volume";

    List<AudioSource> musicAudioSources;
    List<AudioSource> sfxAudioSources;

    [SerializeField]
    private int musicAudioSourcesCount=0;
    [SerializeField]
    private int sfxAudioSourcesCount = 0;

    private void Awake()
    {
        audioSettings = this;
        musicAudioSources = new List<AudioSource>();
        sfxAudioSources = new List<AudioSource>();
        LoadSavedSettings();
    }

    void LoadSavedSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(musicVolumeDataName,musicDefaultVolume);
        sfxVolume = PlayerPrefs.GetFloat(sfxVolumeDataName, sfxDefaultVolume);

    }

    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat(musicVolumeDataName, musicVolume);
        SetVolumeToAudioSources(musicAudioSources, musicVolume);
    }


    public void ChangSFXVolume(float newVolume)
    {
        sfxVolume = newVolume;
        PlayerPrefs.SetFloat(sfxVolumeDataName, sfxVolume);
        SetVolumeToAudioSources(sfxAudioSources, sfxVolume);
        Instantiate(FxBase);
    }

    void SetVolumeToAudioSources(List<AudioSource> audioSources, float volume)
    {
        foreach (AudioSource a in audioSources)
        {
            a.volume = volume;
        }
    }


    public float GetRobot()
    {
        return robotVolume;
    }
    public float GetOlisbo()
    {
        return olisboVolume;
    }
    public float GetCalavera()
    {
        return calaveraVolume;
    }
    public float GetDisco()
    {
        return discoVolume;
    }
    

    public void AddMeToMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Add(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }

    public void RemoveMeFromMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Remove(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }
    public void AddMeToSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Add(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }

    public void RemoveMeFromSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Remove(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }


}
