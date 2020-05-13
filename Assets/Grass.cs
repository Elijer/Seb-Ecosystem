using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Grass : MonoBehaviour {

    public AudioClip sound;

    private AudioSource audioSource;
    private float clipRange = 41f;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
        //Plays rustling sound at a random point to avoid chorusing.
        audioSource.time = Random.Range(1f, clipRange);
        audioSource.Play(0);
        //audioSource.Pause();
    }

    void Update(){
        //use the log function below to fine the maximum length of the clip. Unity says it might not be the same as the actual file. I'm using the maximum length to play the sound from a random point.
        //Turns out this clip has a length of 42.9
        //Debug.Log(audioSource.time);
    }
}
