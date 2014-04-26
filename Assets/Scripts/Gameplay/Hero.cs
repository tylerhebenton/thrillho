using UnityEngine;
using System.Collections;

public class Hero : Unit {

  private const float MAX_DISTANCE_BELLOW = 50f;

  public GameplayDirector GameplayDirector { get; set; }

  void Update() {
    if(GameplayDirector && GameplayDirector.mainCamera) {
      Vector3 delta = GameplayDirector.mainCamera.transform.position - this.transform.position;
      if(delta.y > MAX_DISTANCE_BELLOW) {
        this.Die();
      }
    }
  }

  public override void Die() {
    GameplayDirector.Kill(this);
    base.Die();
  }

  public override void SetFacing(){
    float horizontal = Input.GetAxis(InputAxes.HORIZONTAL);
    if(horizontal > 0){
      direction = Directions.Right;
    } else if (horizontal < 0){
      direction = Directions.Left;
    }
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
