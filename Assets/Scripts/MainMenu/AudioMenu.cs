using System;
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
    private AudioMixer masterMixer;

    void Start() {
        LinkedList<ISaveable>.Enumerator store = SaveLoad.getObjects(typeof(AudioData));
        AudioData saveData = new AudioData();
        if (store.MoveNext()) {
            saveData = (AudioData) store.Current;
            Debug.Log("Has data to be loaded");
        }
        master.SetSlideValue(saveData.master);
        music.SetSlideValue(saveData.music);
        sfx.SetSlideValue(saveData.sfx);

        master.myEvent.AddListener((float data) => {
            saveData.master = data;

            masterMixer.SetFloat("master", data);

            SaveLoad.resetType(typeof(AudioData));
            SaveLoad.addSaveable(saveData);
            SaveLoad.Save();
        });
        music.myEvent.AddListener((float data) => {
            saveData.music = data;
            masterMixer.SetFloat("music", data);

            SaveLoad.resetType(typeof(AudioData));
            SaveLoad.addSaveable(saveData);
            SaveLoad.Save();
        });
        sfx.myEvent.AddListener((float data) => {
            saveData.sfx = data;
            masterMixer.SetFloat("sfx", data);

            SaveLoad.resetType(typeof(AudioData));
            SaveLoad.addSaveable(saveData);
            SaveLoad.Save();
        });
    }
}

[Serializable]
public class AudioData : ISaveable {
    public float master = 0;
    public float music = 0;
    public float sfx = 0;
}