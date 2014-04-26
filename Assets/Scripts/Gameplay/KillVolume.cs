using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D collider){
    Hero player = collider.GetComponent<Hero>();
    if(player) {
      player.Die();
    }
  }
}
