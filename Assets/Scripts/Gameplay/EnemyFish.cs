using UnityEngine;
using System.Collections;

public class EnemyFish : Monster {

	public GameObject gunObject;
	public GameObject AnimProxy;
	public bool move = false;
	public Vector3 velocity;

  public override void OnAggro() {
		move = true;
		Debug.Log ("playinganim on    " + gameObject + "   via Enemyfish.cs");
		AnimProxy.gameObject.animation.Play ();
		base.OnAggro();
    //TODO enable animations
  }

	void Update(){
		if(move){
			this.transform.position = this.transform.position + (Time.deltaTime * velocity);
		}
	}
}

