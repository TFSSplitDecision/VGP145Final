using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour {
    [SerializeField]
    private SliderManager master;
    [SerializeField]
    private SliderManager music;
    [SerializeField]
    private SliderManager sfx;

    [SerializeField]
    private AudioMixerGroup masterMixGroup;
    [SerializeField]
    private AudioMixerGroup musicMixGroup;
    [SerializeField]
    private AudioMixerGroup sfxMixGroup;

    void Start() {
        LinkedList<ISerializable>.Enumerator store = SaveLoad.getObjects(typeof(AudioData));
        AudioData saveData = new AudioData();
        if (store.MoveNext())
            saveData = (AudioData) store.Current;
        master.SetSlideValue(saveData.master);
        music.SetSlideValue(saveData.music);
        sfx.SetSlideValue(saveData.sfx);

        master.myEvent.AddListener((float data) => {
            saveData.master = data;
        });
        music.myEvent.AddListener((float data) => {
            saveData.music = data;
        });
        sfx.myEvent.AddListener((float data) => {
            saveData.master = data;
        });
    }
}

[SerializableAttribute]
public class AudioData {
    public float master = 1;
    public float music = 1;
    public float sfx = 1;
}