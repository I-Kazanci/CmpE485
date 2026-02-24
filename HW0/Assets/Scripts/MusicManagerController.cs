using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerController : MonoBehaviour
{
    private AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
            else
            {
                _audioSource.Play();
            }
        }
    }
}
