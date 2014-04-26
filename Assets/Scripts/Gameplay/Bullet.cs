using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public Vector3 velocity;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    this.transform.position = this.transform.position + (Time.deltaTime * velocity);
	}
}
