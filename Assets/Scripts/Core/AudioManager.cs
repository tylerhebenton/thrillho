using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

  #region singleton
  private static AudioManager _instance = null;

  public static AudioManager Instance {
    get {
      return _instance;
    }
  }


  // Use this for initialization
  void Start() {
    if(_instance != null) {
      Destroy(this);
    } else {
      _instance = this;
    }
  }
  #endregion

  private static Dictionary<string,string> speakerMap = new Dictionary<string,string>{
    //{"Characters/footsteps", "FootstepSpeaker"}
  };

  public void PlaySound(string soundName) {
    if(soundName == null || soundName.Equals("")) {
      return;
    }
    
    Transform speakerGo = FindSpeaker(soundName);
    
    SpeakerExtension speaker = speakerGo.GetComponent<SpeakerExtension>();
    
    AudioClip clip = AudioManager.RandomAudioClip(soundName);
    
    speaker.PlaySound(clip);
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
