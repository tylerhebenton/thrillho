using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

  private Animator animator;
  void Start() {
    animator = this.GetComponent<Animator>();
  }

  public void SetScore(int score) {
    animator.SetInteger("_Score",score);
  }
}
