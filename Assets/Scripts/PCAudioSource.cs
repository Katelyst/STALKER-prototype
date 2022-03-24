using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAudioSource : MonoBehaviour
{
    private AudioSource aSouce;

    private void Awake()
    {
        aSouce = GetComponent<AudioSource>();
    }

    public void PlayAudioOnSource(AudioClip clip)
    {
        aSouce.clip = clip;
        aSouce.Play();
    }
}
