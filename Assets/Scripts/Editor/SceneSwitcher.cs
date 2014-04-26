using UnityEngine;
using System.Collections;
using UnityEditor;

public class SceneSwitcher {
	[MenuItem("Thrillho/Scenes/Startup", false, 0)]
	public static void SwitchToStartup() {
		SwitchToScene ("startup");
	}
	
	[MenuItem("Thrillho/Scenes/Game", false, 1)]
	public static void SwitchToBaseCamp() {
		SwitchToScene ("game");
	}
	
	public static void SwitchToScene(string scene) {
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
			EditorApplication.OpenScene ("Assets/Scenes/" + scene + ".unity");
		}
	}
}
