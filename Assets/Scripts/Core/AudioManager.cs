﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

  #region singleton
  private static AudioManager _instance = null;

  public static AudioManager Instance {
    get {
      if(_instance == null) {
        GameObject template = Resources.Load("Prefabs/Core/AudioManager") as GameObject;
        GameObject am =  GameObject.Instantiate(template) as GameObject;
        am.name = template.name;
        _instance = am.GetComponent<AudioManager>();
        GameObject.DontDestroyOnLoad(am);
      }
    
      return _instance;
    }
  }

  [SerializeField]
  private AudioSource musicTrack;


  #endregion

  private static Dictionary<string,string> speakerMap = new Dictionary<string,string>{
    //{"Characters/footsteps", "FootstepSpeaker"}
  };

  public void PlayMusic() {
    if(musicTrack) {
      musicTrack.Play();
    }
  }

  public void StopMusic() {
    if(musicTrack) {
      musicTrack.Stop();
    }
  }

  public void PlaySound(string soundName) {
    if(soundName == null || soundName.Equals("")) {
      return;
    }
    
    Transform speakerGo = FindSpeaker(soundName);
    
    SpeakerExtension speaker = speakerGo.GetComponent<SpeakerExtension>();
    
    AudioClip clip = AudioManager.RandomAudioClip(soundName);
    
    speaker.PlaySound(clip);
  }

  public void PlayClip(AudioClip clip) {
    FindSpeaker("Main").GetComponent<SpeakerExtension>().PlaySound(clip);
  }

  public static AudioClip RandomAudioClip(string soundName) {
    AudioClip clip = null;
    string soundPath = "Sound/" + soundName;
    
    // if we're given a directory path, assume children are sound files.
    // pick one at random and play it.
    Object[] possibleSounds = Resources.LoadAll(soundPath, typeof(AudioClip));
    if(possibleSounds != null && possibleSounds.Length > 0) {
      clip = (AudioClip)possibleSounds[Random.Range(0, possibleSounds.Length)];
    }
    return clip;
  }

  private Transform FindSpeaker(string soundName) {
    string speakerName = "Main";
    foreach(KeyValuePair<string, string> entry in speakerMap) {
      if(soundName.StartsWith(entry.Key)) {
        speakerName = entry.Value;
        break;
      }
    }
    return this.transform.FindChild(speakerName);
  }
}
