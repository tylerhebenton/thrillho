using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

  void Start() {
    Game.Initialize();

    Debug.Log("Welcome Thrillho!");

    //AudioManager.Instance.PlaySound("GamePlay/golf_clap");
  }

  void Update() {
    if(Input.anyKeyDown) {
      Game.LoadScene(Game.Scenes.Game);
    }
  }
}
