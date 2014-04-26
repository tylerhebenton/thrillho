using UnityEngine;
using System.Collections;

public class UnitConfig : ScriptableObject {

  public float walkSpeed = 1f;

  #region attack_info
  public bool canShoot = true;
  public int numBullets = 3;
  public float fireRate = 3f;
  public float fireCooldown = 3f;
  public GameObject bulletPrefab;
  #endregion

}
