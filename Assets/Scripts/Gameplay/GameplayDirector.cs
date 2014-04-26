using UnityEngine;
using System.Collections;

public class GameplayDirector : MonoBehaviour {

  [SerializeField]
  private Transform[] levels;
  public int curLevelIndex = 0;

  [SerializeField]
  private Transform levelRoot;

  [SerializeField]
  private GameObject gameOverUi;

  // Use this for initialization
  void Start() {
    Initialize();
    LoadLevel(0);
  }

  void Update() {

    if(Input.GetKeyDown("escape")) {
      Game.LoadScene(Game.Scenes.Startup);
    }

    DebugControllsUpdate();
  }

  private void DebugControllsUpdate() {
    if(Feature.enabled(Feature.DEBUG_LEVEL_CONTROLS)) {
      if(Input.GetKeyDown(KeyCode.L)) {
        NextLevel();
      }
    }
  }

  private void Initialize() {
    curLevelIndex = 0;
    this.gameOverUi.SetActive(false);
  }

  public void NextLevel() {
    curLevelIndex += 1;
    LoadLevel(curLevelIndex);
  }

  public void LoadLevel(int index) {
    if(index > levels.Length - 1) {
      //Last level beaten game over with win
      GameOver(true);
    } else if(index < 0) {
      //Goto start scene
      Game.LoadScene(Game.Scenes.Startup);
    } else {
      //Cleanup levels
      foreach(Transform child in levelRoot) {
        Destroy(child.gameObject); 
      }

      Transform newLevel = GameObject.Instantiate(levels[index], levelRoot.transform.position, Quaternion.identity) as Transform;
      newLevel.parent = levelRoot;
      newLevel.gameObject.name = levels[index].gameObject.name;
    }

  }

  /// <summary>
  /// Games the over.
  /// </summary>
  /// <param name="win">If set to <c>true</c> window.</param>
  public void GameOver(bool win) {
    if(win) {
      Debug.Log("YOU A WINNA");
    } else {
      Debug.Log("HAHA");
      this.gameOverUi.SetActive(true);
    }
  }


}
