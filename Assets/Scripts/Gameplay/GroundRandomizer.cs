using UnityEngine;
using System.Collections;

public class GroundRandomizer : MonoBehaviour {

	public GameObject[] parts;
	public Sprite[] groundTile;

	// Use this for initialization
	void Start () {
		int rand;

		rand = Random.Range(0,groundTile.Length);
		gameObject.GetComponent<SpriteRenderer>().sprite = groundTile[rand];

		foreach(GameObject go in parts){
			go.SetActive(false);
		}

		rand = Random.Range(0,parts.Length);
		parts[rand].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
