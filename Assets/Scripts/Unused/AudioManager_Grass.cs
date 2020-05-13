using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager_Grass : MonoBehaviour {
  public Sound[] sounds;

  private int current;

  void Awake(){
    foreach (Sound s in sounds){
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;

      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
    }
  }

  public void Play (string name){
    Sound s = Array.Find(sounds, sound => sound.name == name);
    s.source.Play();
    Debug.Log(s.source.time);
  }

    /*
  public void PlayRandom (){
    if (CentralData.putinMode == false){
      if (current != null){
        sounds[current].source.Pause();
      }
      int randomInt = UnityEngine.Random.Range(0,sounds.Length);
      sounds[randomInt].source.Play();
      current = randomInt;
    }
  }*/

}
