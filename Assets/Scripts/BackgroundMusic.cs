using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        soundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundSource.isPlaying)
        {
            soundSource.Play();
        }
    }
}
