using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Hero))]
public class CarvalloAnimator : MonoBehaviour {
  
  public GameObject model; //this is no longer the model

  private Hero hero;
  private Vector3 originalModelScale;

  [SerializeField]
  private GameObject playerModelTemplate;
  private GameObject rig;
  public Animator rigAnimator;

  void Start(){
    hero = GetComponent<Hero>();
    originalModelScale = model.transform.localScale;
    rig = GameObject.Instantiate(playerModelTemplate, model.transform.position, Quaternion.identity) as GameObject;
    rig.transform.parent = model.transform;
    rig.transform.localScale = Vector3.one;
    rigAnimator = rig.GetComponent<Animator>();
  }

  void Update(){
    float facingX = (hero.direction == Unit.Directions.Right) ? 1 : -1;
    if(model) {
      model.transform.localScale = new Vector3(originalModelScale.x * facingX, originalModelScale.y, originalModelScale.z);
    }
  }

  public void SetVelocity(Vector2 vel) {
    rigAnimator.SetFloat("velocityX", vel.x);
    rigAnimator.SetFloat("velocityY", vel.y);
  }


  public void Attack1() {
    rigAnimator.SetTrigger("attack1");
  }

  public void Attack2() {
    rigAnimator.SetTrigger("attack2");
  }

  public void Jump() {
    rigAnimator.SetTrigger("jump");
  }

  public void Grounded() {
    rigAnimator.SetTrigger("grounded");
  }
}
