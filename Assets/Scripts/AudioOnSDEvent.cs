using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;

[RequireComponent(typeof(AudioSource))]
public class AudioOnSDEvent : MonoBehaviour
{
    [Header("Event listeners from interactable")]
    [SerializeField]
    private SDBool onInteractListener;

    [Header("Optional audio clips overriding the ones already in the source. If null it uses already set clip")]
    [SerializeField]
    private AudioClip onInteractClip;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        if(onInteractListener)
            onInteractListener.OnValueChangedEvent += PlayOnInteract;

        if(source.clip == null && onInteractClip == null)
        {
            Debug.LogWarning("YOU DUMMY! No audioclips are selected for play on obj: " + gameObject.name);
        }
    }

    private void PlayOnInteract(bool data)
    {
        if(onInteractClip != null)
            source.clip = onInteractClip;
    }
}
