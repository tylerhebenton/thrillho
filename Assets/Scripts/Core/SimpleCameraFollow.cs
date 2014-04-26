using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {

	public GameObject Player;

	float xPos;

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
            if(Player != null && Player.transform != null){
		if(gameObject.transform.position.x != Player.transform.position.x){
			xPos = Mathf.Lerp(gameObject.transform.position.x, Player.gameObject.transform.position.x+3, Time.deltaTime * 1.99f);
		}

		gameObject.transform.position = new Vector2(xPos, gameObject.transform.position.y);
    } else {
      Player = GameObject.Find("LeeCarvallo(Clone)");
    }
	}
}
