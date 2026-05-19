using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _fxSource;
    [SerializeField] private AudioSource _musicSource;

    public void SetFXVolume(float level)
    {
        _audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }

    public void PlayFx(AudioClip clip)
    {
        _fxSource.clip = clip;
        _fxSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }


}
