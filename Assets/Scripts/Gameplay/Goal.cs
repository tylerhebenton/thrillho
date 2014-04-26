using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D collider) {
    HeroBody body = collider.GetComponent<HeroBody>();
    if(body && body.hero) {
      body.hero.GameplayDirector.NextLevel();
    }
  }
  
  void OnDrawGizmos() {
    Gizmos.color = Color.green;
    BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
    if(boxCollider) {
      Gizmos.DrawWireCube(this.transform.position, new Vector3(boxCollider.size.x, boxCollider.size.y, 1f));
    }
  }
}
