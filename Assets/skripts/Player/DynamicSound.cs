using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DynamicSound : MonoBehaviour
{

    public AudioClip[] dynamicLoops;
    private AudioSource[] audioSources;
    public float volume;
    private float dynamicIndex = 0.0f;
    public bool playPredicates;

    // Called before the first frame
    void Start() {
        audioSources = new AudioSource[dynamicLoops.Length];
        for (int i = 0; i < dynamicLoops.Length; ++i) {
            audioSources[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
            audioSources[i].clip = dynamicLoops[i];
            audioSources[i].loop = true;
            audioSources[i].Play();
            audioSources[i].volume = 0.0f;
        }
    }

    // Called every rendered frame
    void Update() {
        for (int i = 0; i < dynamicLoops.Length; ++i) {
            if (playPredicates) {
                if (i < (int)dynamicIndex) {
                    audioSources[i].volume = volume;
                } else if (i == (int)dynamicIndex) {
                    audioSources[i].volume = volume * (dynamicIndex - (int)dynamicIndex);
                } else {
                    audioSources[i].volume = 0.0f;
                }
            } else {
                if ((int)dynamicIndex >= 0 && i == (int)dynamicIndex - 1) {
                    audioSources[i].volume = volume * (1 - (dynamicIndex - (int)dynamicIndex));
                } else if (i == (int)dynamicIndex) {
                    audioSources[i].volume = volume * (dynamicIndex - (int)dynamicIndex);
                } else {
                    audioSources[i].volume = 0.0f;
                }
            } // End predicate / no predicate if statement
        } // End for
    }

    /// <summary>
    /// Sets the currently playing dynamic loop
    /// </summary>
    /// <param name="index">The index to set the dynamic loop state to</param>
    /// <exception>IndexOutOfRangeException</exception>
    public void SetDynamicIndex(float index) {
        if (index < 0 || index > dynamicLoops.Length) {
             Debug.LogException(new IndexOutOfRangeException(), this);
        }
        dynamicIndex = index;
    }

    /// <summary>
    /// Returns the currently playing dynamic loop state index
    /// </summary>
    /// <returns>dynamic loop state index</returns>
    public float GetDynamicIndex() {
        return dynamicIndex;
    }
}
