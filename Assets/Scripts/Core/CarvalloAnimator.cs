using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Hero))]
public class CarvalloAnimator : MonoBehaviour {
  
  public GameObject model;

  private Hero hero;
  private Vector3 originalModelScale;

  void Start(){
    hero = GetComponent<Hero>();
    originalModelScale = model.transform.localScale;
  }

  void Update(){
    float facingX = (hero.direction == Unit.Directions.Right) ? 1 : -1;
    if(model) {
      model.transform.localScale = new Vector3(originalModelScale.x * facingX, originalModelScale.y, originalModelScale.z);
    }
  }

}
