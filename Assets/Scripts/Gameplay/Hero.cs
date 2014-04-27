using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Hero : Unit {

  [SerializeField]
  private GameObject respawnPlatformPrefab;

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

    GameObject respawnPlatform = GameObject.Instantiate(respawnPlatformPrefab, transform.position + Vector3.down * 2, transform.rotation) as GameObject;

    invincible = true;
    yield return new WaitForSeconds(0.1f);
    CarvalloAnimator ca = GetComponent<CarvalloAnimator>();
    bool ticktock = false;
    Vector3 modelLocalPos = ca.model.transform.localPosition;
    for(int i = 0; i < 50; ++i){
      if(ticktock){
        ca.model.transform.position = Camera.main.transform.position + Vector3.back*10;
      } else {
        ca.model.transform.localPosition = modelLocalPos;
      }
      yield return new WaitForSeconds(0.02f);
      ticktock = !ticktock;
    }
    ca.model.transform.localPosition = modelLocalPos;
    invincible = false;
    yield return new WaitForSeconds(0.5f);
    List<Renderer> platformRenderers = respawnPlatform.GetComponentsInChildren<Renderer>().ToList();
    for(int i = 0; i < 50; ++i){
      yield return new WaitForSeconds(0.02f);
      foreach(Renderer r in platformRenderers){
        r.enabled = !r.enabled;
      }
    }
    GameObject.Destroy(respawnPlatform);
  }
}
