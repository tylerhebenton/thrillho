using UnityEngine;
using System.Collections;

public class EnemyTurtle : Monster {

	public GameObject gunObject;
	public GameObject prefab;
	public GameObject AnimProxy;

  public override void OnAggro() {
		Debug.Log ("playinganim on turtle");
		AnimProxy.gameObject.animation.Play ();
		base.OnAggro();
    //TODO enable animations
  }
}
