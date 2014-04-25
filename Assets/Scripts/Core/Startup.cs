using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

	void Start () {
		Game.Initialize ();

    Debug.Log("Welcome Thrillho!");

    Game.LoadScene(Game.Scenes.Game);
	}
}
