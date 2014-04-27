using UnityEngine;
using System.Collections;

public class TurtleAnimProxy : MonoBehaviour {

	public GameObject gunObject;
	public GameObject prefab;

	public void Shoot(){
		GameObject Bullet;
		Bullet = Instantiate(prefab, gunObject.transform.position, gunObject.transform.rotation) as GameObject;
		Bullet.GetComponent<Bullet>().velocity = gunObject.transform.TransformDirection(Vector3.up * 4);
	}

	
}
