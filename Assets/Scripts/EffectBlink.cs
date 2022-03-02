using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectBlink : MonoBehaviour
{
    public MaskableGraphic imageToToggle;

    public float minimum = 0.3f;
    public float maximum = 1f;
    public float cyclesPerSecond = 2.0f;
    private float a;
    private bool increasing = true;
    Color color;

    void Start()
    {
        imageToToggle = gameObject.GetComponent<MaskableGraphic>();
        color = imageToToggle.color;
        a = maximum;
    }



    void Update()
    {
        float t = Time.deltaTime;
        if (a >= maximum) increasing = false;
        if (a <= minimum) increasing = true;
        a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
        color.a = a;
        imageToToggle.color = color;
    }
}
