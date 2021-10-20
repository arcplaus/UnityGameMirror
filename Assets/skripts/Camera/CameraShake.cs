using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Vector3 originalPos;
    public float shakeFactor = 0.0f;
    public float shakeDecay = 0.7f;
    // Start is called before the first frame update
    void Start() {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update() {
        transform.localPosition = originalPos + new Vector3(Random.Range(-shakeFactor,shakeFactor),
                                                       Random.Range(-shakeFactor,shakeFactor),
                                                       Random.Range(-shakeFactor,shakeFactor));
    }

    void FixedUpdate() {
        shakeFactor *= shakeDecay;
    }
}
