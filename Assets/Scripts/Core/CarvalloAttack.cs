using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class CarvalloAttack : MonoBehaviour {

  [SerializeField]
  private CarvalloController controller;
  [SerializeField]
  private GameObject bulletPrefab;
  [SerializeField]
  private float speed;

  private List<Monster> monstersInRange = new List<Monster>();
  private List<Bullet> bulletsInRange = new List<Bullet>();

  private BoxCollider2D boxCollider;

  void Start(){
    boxCollider = GetComponent<BoxCollider2D>();
    controller.MeleeFired += Melee;
    controller.RangedFired += Ranged;
  }

  void Melee(float horizontal, float vertical){
    List<Monster> monstersToRemove = new List<Monster>();
    foreach(Monster monster in monstersInRange){
      if(monster == null){
        monstersToRemove.Add(monster);
        continue;
      }
      monster.Die();
    }
    foreach(Monster monster in monstersToRemove){
      monstersInRange.Remove(monster);
    }
    List<Bullet> bulletsToRemove = new List<Bullet>();
    foreach(Bullet bullet in bulletsInRange){
      if(bullet == null){
        bulletsToRemove.Add(bullet);
        continue;
      }
      if(bullet.GetType() != bulletPrefab.GetType()){
        if(bullet.transform.position.x > controller.transform.position.x
           && bullet.velocity.x < 0){
          bullet.velocity = new Vector3(-bullet.velocity.x*3, bullet.velocity.y*3, bullet.velocity.z);
        } else if(bullet.transform.position.x < controller.transform.position.x
                  && bullet.velocity.x > 0){
          bullet.velocity = new Vector3(-bullet.velocity.x*3, bullet.velocity.y*3, bullet.velocity.z);
        }
        if(bullet.transform.position.y > controller.transform.position.y
           && bullet.velocity.y < 0){
          bullet.velocity = new Vector3(bullet.velocity.x*3, -bullet.velocity.y*3, bullet.velocity.z);
        } else if(bullet.transform.position.y < controller.transform.position.y
                  && bullet.velocity.y > 0){
          bullet.velocity = new Vector3(bullet.velocity.x*3, -bullet.velocity.y*3, bullet.velocity.z);
        }
        KillVolume kv = bullet.GetComponent<KillVolume>();
        if(kv){
          kv.targets = bulletPrefab.GetComponent<KillVolume>().targets;
        }
      }
    }
    foreach (Bullet b in bulletsToRemove){
      bulletsInRange.Remove(b);
    }
    if(bulletsToRemove.Count > 0) {
      AudioManager.Instance.PlaySound("Gameplay/HitEnemyBullet");
    } else {
      AudioManager.Instance.PlaySound("Gameplay/GolfSwing");
    }
  }

  void Ranged(float horizontal, float vertical){
    GameObject bulletGO = GameObject.Instantiate(bulletPrefab,transform.position,transform.rotation) as GameObject;
    Bullet bullet = bulletGO.GetComponent<Bullet>();
    if(Mathf.Abs(horizontal) < 0.1f && Mathf.Abs(vertical) < 0.1f){
      bullet.velocity = transform.right * speed;
    } else {
      bullet.velocity = new Vector3(horizontal, -vertical, 0).normalized*speed;
    }
    AudioManager.Instance.PlaySound("Gameplay/HitEnemyBullet");
  }

  void OnTriggerEnter2D(Collider2D collider){
    Monster m = collider.GetComponent<Monster>();
    if(m){
      monstersInRange.Add(m);
    }
    Bullet b = collider.GetComponent<Bullet>();
    if(b){
      bulletsInRange.Add(b);
    }
  }

  void OnTriggerExit2D(Collider2D collider){
    Monster m = collider.GetComponent<Monster>();
    if(m && monstersInRange.Contains(m)){
      monstersInRange.Remove(m);
    }
    Bullet b = collider.GetComponent<Bullet>();
    if(b && bulletsInRange.Contains(b)){
      bulletsInRange.Remove(b);
    }
  }

}
