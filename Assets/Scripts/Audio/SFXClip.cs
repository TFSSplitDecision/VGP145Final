using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

/// <summary>
/// Sound clip abstraction. A data object that helps us add variety and randomness
/// to sound effects.
/// </summary>
[CreateAssetMenu(fileName = "SFXClip", menuName = "Data/SFXClip", order = 1)]
public class SFXClip : ScriptableObject
{
    [Tooltip("The sound channel the audio will play at")]
    public AudioMixerGroup mixerGroup;

    [Tooltip("Multiple sound clips. In case we want variation")]
    public AudioClip[] clips;
    public float minPitch = 1.0f;
    public float maxPitch = 1.0f;

    public AudioClip NextClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
    public float NextPitch()
    {
        return Random.Range(minPitch, maxPitch);
    }


}
