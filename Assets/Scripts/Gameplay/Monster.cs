using UnityEngine;
using System.Collections;

public class Monster : Unit {

  public enum MonsterStates {
    Idle,
    Aggro,
    Dead
  }

  public MonsterStates state = MonsterStates.Idle;

  void Update() {
    if(state == MonsterStates.Aggro) {
      FireUpdate();
    }
  }

  public void Aggro() {
    if(state == MonsterStates.Idle) {
      Debug.Log("RAWR",this);
      state = MonsterStates.Aggro;
    }
  }

  private void FireUpdate() {
    if(unitConfig == null || unitConfig.canShoot == false) {
      return;
    }

    float curTime = Time.fixedTime;
    if(curTime > this.lastShootTime + unitConfig.fireCooldown) {
      //Debug.Log("BLAM", this);

      if(unitConfig.bulletPrefab == null) {
        Debug.LogError("Unable to fire without a bulletPrefab", this);
      } else {
        GameObject.Instantiate(unitConfig.bulletPrefab, this.transform.position, Quaternion.identity);
      }

      this.lastShootTime = curTime;
    }
  }
}
