using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

  public enum Targets {
    Heros,
    Monsters,
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

  }
}
