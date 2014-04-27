using UnityEngine;
using System.Collections;

public class YESSSBLOOD : MonoBehaviour {

	public GameObject bloodOverlay;

	void OnTriggerEnter2D(Collider2D collider){
	if(collider.GetComponent<HeroBody>()){
			bloodOverlay.SetActive(true);
		}
	}

}
