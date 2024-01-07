using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   
    public AudioClip musicToPlay;
    [Range(0f, 1f)] 
    public float volume = 1.0f;

    private AudioSource audioSource;
    private bool isPlaying;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; 
        audioSource.volume = volume;
    }

    private void Update()
    {
        if (audioSource.volume != volume)
        {
            audioSource.volume = volume;
        }
        
        if (!isPlaying && musicToPlay != null)
        {
            PlayMusic(musicToPlay);
            isPlaying = true; 
        }
    }
    
    private void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }

        musicToPlay = newMusic;
        audioSource.clip = newMusic;
        isPlaying = false;
    }
}
