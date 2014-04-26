using UnityEngine;
using System.Collections;

public static class Game {

  public enum Scenes {
    Startup,
    Game
  }

  public static void Initialize() {
    //Initialize app level stuff here
  }

  public static void LoadScene(Game.Scenes scene) {
    Application.LoadLevel(scene.ToString().ToLower());
  }

}
