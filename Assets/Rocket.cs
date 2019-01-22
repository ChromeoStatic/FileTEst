using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource rocket;
    public Vector3 speed = new Vector3(0,1000.0f,0);
    public Vector3 velocityRot = new Vector3(0, 0, 80.0f);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocket = GetComponent<AudioSource>();
        
    }

    void Update()
    {
      
        Thrust();
        Rotate();
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(speed*Time.deltaTime);
            if (rocket.isPlaying == false) {
                rocket.Play();
            }
        } else {
            rocket.Stop();
        }
    }
    private void Rotate() {

        rb.freezeRotation = true;   //take manual control of rotation when used

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(velocityRot * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-velocityRot * Time.deltaTime);
        }

        rb.freezeRotation = false;  //resume physics rotation 
    }
}
