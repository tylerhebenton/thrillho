using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

  public enum Directions {
    Left,
    Right
  }


  public Directions direction = Directions.Left;
  public UnitConfig unitConfig;

  protected float lastShootTime = 0f;

  public virtual void Die() {
    //TODO check vulenrability?
    //TODO play death animation?
    
    Destroy(this.gameObject);
  }
}
