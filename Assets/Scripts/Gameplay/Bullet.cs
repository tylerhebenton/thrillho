using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public Vector3 velocity;
  public float maxLife = 3f;
  private float endOfLife = 0f;


	// Use this for initialization
	void Start () {
    endOfLife = Time.fixedTime + maxLife;
	}
	
	// Update is called once per frame
	void Update () {
    this.transform.position = this.transform.position + (Time.deltaTime * velocity);

    if(endOfLife > 0f && Time.fixedTime > endOfLife) {
      GameObject.Destroy(this.gameObject);
    }
	}
}
