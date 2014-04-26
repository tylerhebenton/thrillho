using UnityEngine;
using System.Collections;

public class MonsterWaker : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D collider) {
    Monster monster = collider.GetComponent<Monster>();
    if(monster) {
      monster.Aggro();
    }
  }
}
