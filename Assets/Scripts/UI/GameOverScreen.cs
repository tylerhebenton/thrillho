using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {


  const float INPUT_DELAY = 2f;
  float inputAllowedTime = 0f;
  bool waitingOnInput = false;

  void Update() {
    if(waitingOnInput && Input.anyKeyDown && Time.fixedTime > inputAllowedTime) {
      SelectNo();
    }
  }

  void OnEnable() {
    inputAllowedTime = Time.fixedTime + INPUT_DELAY;
    waitingOnInput = true;
    AudioManager.Instance.PlaySound("EpisodeVox/WouldYouLikeToPlayAgain");
  }

  public void SelectNo() {
    waitingOnInput = false;
    AudioManager.Instance.PlaySound("EpisodeVox/YouHaveSelectedNo");
    UkenTimer.SetTimeout(4f, () => {
      Game.LoadScene(Game.Scenes.Startup);
    });
  }
}
