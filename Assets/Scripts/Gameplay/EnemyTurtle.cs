using UnityEngine;
using System.Collections;

public class EnemyTurtle : Monster {

	public GameObject gunObject;
	public GameObject bullet;

	public void Shoot(){
		GameObject Bullet;
		Bullet = Instantiate(bullet, gunObject.transform.position, gunObject.transform.rotation) as GameObject;
		bullet.GetComponent<Bullet>().velocity = gunObject.transform.TransformDirection(Vector3.up * 4);
	}

  public override void OnAggro() {
		this.gameObject.animation.Play ();
   		base.OnAggro();
    //TODO enable animations
  }
}
