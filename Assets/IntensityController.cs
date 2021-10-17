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
    private Vignette vg;
    private const float VG_INTENSITY_MIN = 0.25f;
    private const float VG_INTENSITY_MAX_DELTA = 0.10f;
    private Grain gn;
    private const float GN_INTENSITY_MIN = 0.25f;
    private const float GN_INTENSITY_MAX_DELTA = 0.6f;
    private LensDistortion ld;
    private const float LD_INTENSITY_MAX = 0.9f;

    void Start() {
        post.TryGetSettings(out ca);
        post.TryGetSettings(out vg);
        post.TryGetSettings(out gn);
        post.TryGetSettings(out ld);
    }

    // Update is called once per frame
    void Update() {
        if (intensity > 1.0f) intensity = 1.0f;
        if (intensity < 0.0f) intensity = 0.0f;
        ca.intensity.value = intensity * chromaticAberrationModifier;
        vg.intensity.value = VG_INTENSITY_MIN + VG_INTENSITY_MAX_DELTA * intensity;
        gn.intensity.value = GN_INTENSITY_MIN + GN_INTENSITY_MAX_DELTA * intensity;
        ld.intensity.value = LD_INTENSITY_MAX * intensity;
        dynamicSound.SetDynamicIndex(dynamicSound.dynamicLoops.Length * intensity);
    }
}
