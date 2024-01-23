using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioClip;  // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    public float interval = 5f;  // Adjust this value to set the interval in seconds

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Invoke the PlayAudioEffect method every 'interval' seconds, starting after 0 seconds
        InvokeRepeating("PlayAudioEffect", 5f, interval);
    }

    // Method to play the audio effect
    void PlayAudioEffect()
    {
        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
