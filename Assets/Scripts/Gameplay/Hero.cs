using UnityEngine;
using System.Collections;

public class Hero : Unit {

  private const float MAX_DISTANCE_BELLOW = 50f;

  private bool invincible = false;

  public GameplayDirector GameplayDirector { get; set; }

  public override void Update() {
    base.Update();
    if(GameplayDirector && GameplayDirector.mainCamera) {
      Vector3 delta = GameplayDirector.mainCamera.transform.position - this.transform.position;
      if(delta.y > MAX_DISTANCE_BELLOW) {
        this.Die();
      }
    }
  }

  public override void Die() {
    if(invincible){
      Debug.Log("Too invincible to die");
      return;
    }
    if(GameplayDirector != null){
      GameplayDirector.Kill(this);
    }
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

  public void ActivateRespawnInvincibility(){
    StartCoroutine(RespawnInternal());
  }
  
  private IEnumerator RespawnInternal(){
    invincible = true;
    CarvalloAnimator ca = GetComponent<CarvalloAnimator>();
    for(int i = 0; i < 50; ++i){
      ca.model.gameObject.SetActive(!ca.model.gameObject.activeInHierarchy);
      yield return new WaitForSeconds(0.02f);
    }
    ca.model.gameObject.SetActive(true);
    invincible = false;
  }
}
