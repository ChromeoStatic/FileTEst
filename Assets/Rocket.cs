using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        ProcessInput();    
    }

    private void ProcessInput() {

        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("up and away");
        }

        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("going left");
        }else if (Input.GetKey(KeyCode.D)) {
            Debug.Log("going right");
        }
    }
}
