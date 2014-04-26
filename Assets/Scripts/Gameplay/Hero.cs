using UnityEngine;
using System.Collections;

public class Hero : Unit {

	public GameplayDirector GameplayDirector { get; set; }

	public override void Die() {
    GameplayDirector.Kill(this);
    base.Die();
	}
}
