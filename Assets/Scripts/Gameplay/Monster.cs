using UnityEngine;
using System.Collections;

public class Monster : Unit {

  void Update() {
    FireUpdate();
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
