using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
  public GameObject player;
  public GameObject projectile;
  private void OnCollisionEnter2D(Collision2D obj) {
    if(obj.gameObject.CompareTag("Meteors")){
        player.GetComponent<PlayerHealth>().TakeDamage(100);
    }
     if(obj.gameObject.CompareTag("Enemy")){
        player.GetComponent<PlayerHealth>().TakeDamage(10);
    }
  }
  private void OnTriggerEnter2D(Collider2D obj) {
    if(obj.gameObject.CompareTag("MovementSpeed")){
        Destroy(obj.gameObject);
            player.GetComponent<PlayerMove>().ChangeSpeed(5f); 
    }
    else if (obj.gameObject.CompareTag("FireRate"))
    {
        Destroy(obj.gameObject);
            projectile.GetComponent<ProjectileWeapon>().ChangeSpeed(0.5f);
    }
  }
}
