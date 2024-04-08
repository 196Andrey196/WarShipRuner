using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource _musicManager;
    [SerializeField] private AudioSource _soundEfectsManager;
    [SerializeField] private AudioSource _destroyAudioSorce;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private bool _muteMusic;
    private float _volumeMusic = 0.25f;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Start()
    {
        _muteMusic = false;

        PlayMusic(_defaultMusic);
    }

    public void PlaySoundEfects(AudioClip sound, float volume)
    {
        if (_soundEfectsManager != null && sound != null)
        {
            _soundEfectsManager.volume = volume;
            _soundEfectsManager.clip = sound;
            _soundEfectsManager.Play();
        }

    }
    public void DestroySoundEfects(AudioClip sound, float volume)
    {
        if (_destroyAudioSorce != null && sound != null)
        {
            _destroyAudioSorce.volume = volume;
            _destroyAudioSorce.clip = sound;
            _destroyAudioSorce.Play();
        }

    }
    public void PlayIndividualSound(AudioSource audioSource, AudioClip sound, float volume)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.volume = volume;
            audioSource.clip = sound;
            audioSource.Play();
        }

    }

    public void PlayMusic(AudioClip music)
    {
        if (_musicManager != null && music != null)
        {
            _musicManager.volume = _volumeMusic;
            _musicManager.clip = music;
            _musicManager.Play();
        }
    }
    public void MuteMusic()
    {
        if (_muteMusic) _musicManager.mute = false;
        else _musicManager.mute = true;

    }
}
