using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public GameplayDirector GameplayDirector { get; set; }
	
	public void Die() {
    //TODO check vulenrability?

    GameplayDirector.Kill(this);
    //TODO play death animation?

    Destroy(this.gameObject);
	}
}
