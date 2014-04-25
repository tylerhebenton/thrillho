using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

  void Start() {
    Game.Initialize();

    Debug.Log("Welcome Thrillho!");

    //AudioManager.Instance.PlaySound("GamePlay/golf_clap");

    Game.LoadScene(Game.Scenes.Game);
  }
}
