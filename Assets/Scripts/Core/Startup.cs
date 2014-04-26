using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

  [SerializeField]
  private GameObject tapToStartUi;

  [SerializeField]
  private GameObject splashUi;


  void Start() {
    Game.Initialize();
  }

  void Update() {
    if(Input.anyKeyDown) {
      tapToStartUi.SetActive(false);
      LoadGame();
    }
  }

  private void LoadGame() {
    AudioManager.Instance.PlaySound("EpisodeVox/ThrillhouseSHORT");
    splashUi.SetActive(true);

    UkenTimer.SetTimeout(4f, () => {
      Game.LoadScene(Game.Scenes.Game);
    });
  }
}
