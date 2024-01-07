using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [Tooltip("Liste des musiques à jouer")]
    public AudioClip[] musicClips; 

    [Tooltip("Volume sonore de la musique")]
    [Range(0f, 1f)]
    public float volume = 1.0f; 

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.loop = true; 
        audioSource.playOnAwake = false;
        audioSource.volume = volume; 

        if (musicClips.Length > 0)
        {
            PlayMusic(0); 
        }
    }
    
    public void PlayMusic(int clipIndex)
    {
        if(clipIndex >= 0 && clipIndex < musicClips.Length)
        {
            audioSource.clip = musicClips[clipIndex]; 
            audioSource.Play(); 
        }
    }
}