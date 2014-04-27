using UnityEngine;
using System.Collections;

public class ClubSelector : MonoBehaviour {

  bool acceptingInput = false;
	// Use this for initialization
	void Start () {
    Game.Initialize();
    acceptingInput = false;

    UkenTimer.SetTimeout(3f, () => {
      AudioManager.Instance.PlaySound("EpisodeVox/IAmCarvallo");
      UkenTimer.SetTimeout(2f, () => {
        AudioManager.Instance.PlaySound("EpisodeVox/ChooseAClub");
        UkenTimer.SetTimeout(2f, () => {
          acceptingInput = true;
        });
      });
    });
	}
	
	// Update is called once per frame
	void Update () {
    if(acceptingInput && Input.anyKeyDown) {
      SelectClub();
      acceptingInput = false;
    }
	}

  
  private void SelectClub() {
    AudioManager.Instance.PlaySound("EpisodeVox/YouHaveChosen3wood");
    
    UkenTimer.SetTimeout(4f, () => {
      Game.LoadScene(Game.Scenes.Game);
    });
  }
}
