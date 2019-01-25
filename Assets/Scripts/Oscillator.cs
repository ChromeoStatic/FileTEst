#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10.0f, 10.0f, 10.0f);
    [SerializeField] float period = 2.0f;

    float movementFactor;  //0 not moved, 1 fully moved
    Vector3 startingPoint;

    void Start() {
        startingPoint = transform.position;   
    }
    void Update() {
        if (period <= Mathf.Epsilon)
            return;
        float cycles = Time.time / period;  //grows continually from 0
        const float tau = Mathf.PI * 2f;  //about 6.28
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave * 2.0f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPoint + offset;

    }
}
