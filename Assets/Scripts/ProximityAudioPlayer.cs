using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProximityMusicPlayer : MonoBehaviour
{
    public AudioClip soundClip; 
    public float volume = 1.0f; 
    public float triggerRadius = 5.0f; 

    private AudioSource audioSource;
    private bool isPlayerNear = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.volume = volume;
        audioSource.loop = true; 
        audioSource.playOnAwake = false; 
        audioSource.spatialBlend = 1.0f; 

        
        audioSource.maxDistance = triggerRadius;

        //  SphereCollider pour détecter la proximité du joueur
        SphereCollider trigger = gameObject.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        trigger.radius = triggerRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNear = true;
            audioSource.Play(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            audioSource.Stop(); 
        }
    }
}