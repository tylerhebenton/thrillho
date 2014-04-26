using UnityEngine;
using System.Collections;

public class Hero : Unit {

  public GameplayDirector GameplayDirector { get; set; }

  public override void Die() {
    GameplayDirector.Kill(this);
    base.Die();
  }

  void OnTriggerEnter2D(Collider2D collider) {
    Bullet bullet = collider.GetComponent<Bullet>();
    if(bullet) {
      Debug.Log("Hit by bullet");
      GameObject.Destroy(bullet.gameObject);
      this.Die();
    }
    
  }
}
