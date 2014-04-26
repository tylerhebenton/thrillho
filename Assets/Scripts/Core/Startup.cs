using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

  void Start() {
    Game.Initialize();
  }

  void Update() {
    if(Input.anyKeyDown) {
      LoadGame();
    }
  }

  private void LoadGame() {
    AudioManager.Instance.PlaySound("EpisodeVox/ThrillhouseSHORT");

    UkenTimer.SetTimeout(4f, () => {
      Game.LoadScene(Game.Scenes.Game);
    });
  }
}
