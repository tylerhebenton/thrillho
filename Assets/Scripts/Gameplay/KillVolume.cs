using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		/* Platformer2D reference code
		baked_EnemyController bec = collider.GetComponent<baked_EnemyController>();
		if(bec){
			bec.Redirect(walkDirection);
		}
		*/
	}
}
