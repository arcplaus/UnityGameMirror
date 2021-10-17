using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class IntensityController : MonoBehaviour
{

    public float intensity;
    public float chromaticAberrationModifier = 1.5f;
    public DynamicSound dynamicSound;
    public PostProcessProfile post;
    private ChromaticAberration ca;

    void Start() {
        post.TryGetSettings(out ca);
    }

    // Update is called once per frame
    void Update() {
        if (intensity > 1.0f) intensity = 1.0f;
        if (intensity < 0.0f) intensity = 0.0f;
        ca.intensity.value = intensity * chromaticAberrationModifier;
        dynamicSound.SetDynamicIndex(dynamicSound.dynamicLoops.Length * intensity);
    }
}
