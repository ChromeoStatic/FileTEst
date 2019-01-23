using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;
    Rigidbody rb;
    AudioSource audioSource;
    public Vector3 speed = new Vector3(0,1000.0f,0);
    public Vector3 velocityRot = new Vector3(0, 0, 80.0f);
    public float timeToNextScene = 2.0f;
    enum State {Alive,Dying,Transcending};
    State state = State.Alive;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update() {
        if (state == State.Alive) {

            Thrust();
            Rotate();
        }
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(speed*Time.deltaTime);
            if (audioSource.isPlaying == false) {
                audioSource.PlayOneShot(mainEngine);
            }
        } else {
            audioSource.Stop();
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

    private void OnCollisionEnter(Collision collision) {

        if (state != State.Alive) {
            return;                                             //Exit function if not palying
        }
        
        switch (collision.gameObject.tag) {
            
            case "Friendly":
                //do nothing
                break;
            case "Fuel":
                print("Fuel up");
                break;
            case "Finish":
                audioSource.Stop();
                state = State.Transcending;
                audioSource.PlayOneShot(winSound);
                Invoke("LoadNextScene", timeToNextScene);
                break;
            default:
                state = State.Dying;
                audioSource.Stop();
                audioSource.PlayOneShot(deathSound, 0.3f);
                Invoke("Restart", timeToNextScene);
                break;
        }

    }

    void Restart() {
        
        SceneManager.LoadScene(0);   
    }
    void LoadNextScene() {
        
        SceneManager.LoadScene(1);
    }
}
