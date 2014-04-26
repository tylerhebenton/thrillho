using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

  public virtual void Die() {
    //TODO check vulenrability?
    //TODO play death animation?
    
    Destroy(this.gameObject);
  }
}
