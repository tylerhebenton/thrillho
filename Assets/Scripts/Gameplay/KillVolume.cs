using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

  public enum Targets {
    Heros,
    Monsters,
    Bullets,
    All
  }

  public Targets targets = Targets.Heros;

  void OnTriggerEnter2D(Collider2D collider) {
    if(targets == Targets.Heros || targets == Targets.All) {
      Hero player = collider.GetComponent<Hero>();
      if(player) {
        player.Die();
      }
    }

    if(targets == Targets.Monsters || targets == Targets.All) {
      Monster monster = collider.GetComponent<Monster>();
      if(monster) {
        monster.Die();
      }
    }

    if(targets == Targets.Bullets || targets == Targets.All) {
      Bullet bullet = collider.GetComponent<Bullet>();
      if(bullet) {
        Debug.Log("Collide with bullet");
        GameObject.Destroy(bullet.gameObject);
      }
    }

  }
}
