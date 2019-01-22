using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource rocket;
    public float speed = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocket = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        ProcessInput();    
    }

    private void ProcessInput() {

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up);
            if (rocket.isPlaying == false) {
                rocket.Play();
            }
        } else {
            rocket.Stop();
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,speed*Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-speed*Time.deltaTime);
        }
    }
}
