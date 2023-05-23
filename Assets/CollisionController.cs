using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
  public GameObject ObjectOfInt;
  public GameObject projectile;
    private void OnCollisionEnter2D(Collision2D obj) {
    if(ObjectOfInt.gameObject.CompareTag("Player")){
      if(obj.gameObject.CompareTag("Meteors")){
         ObjectOfInt.GetComponent<PlayerHealth>().TakeDamage(100);
     }
       if(obj.gameObject.CompareTag("Enemy"))
         ObjectOfInt.GetComponent<PlayerHealth>().TakeDamage(10);
    }
    else if(ObjectOfInt.gameObject.CompareTag("Enemy")){
      if(obj.gameObject.CompareTag("Player"))
       ObjectOfInt.GetComponent<EnemyHealth>().TakeDamage(10);
       Debug.Log("Hit");
    }
  }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (ObjectOfInt.gameObject.CompareTag("Player"))
        {
            if (obj.gameObject.CompareTag("MovementSpeed"))
            {
                Destroy(obj.gameObject);
                ObjectOfInt.GetComponent<PlayerMove>().ChangeSpeed(5f);
            }
            else if (obj.gameObject.CompareTag("Enemy"))
            {
                ObjectOfInt.GetComponent<PlayerHealth>().TakeDamage(10);
            }
            else if (obj.gameObject.CompareTag("FireRate"))
            {
                Destroy(obj.gameObject);
                projectile.GetComponent<ProjectileWeapon>().ChangeSpeed(0.25f);
            }
            else if (obj.gameObject.CompareTag("EnemyShot"))
            {
                Destroy(obj.gameObject);
                ObjectOfInt.GetComponent<PlayerHealth>().TakeDamage(10);
            }
            else if (obj.gameObject.CompareTag("Meteors"))
            {
                ObjectOfInt.GetComponent<PlayerHealth>().TakeDamage(75);
            }
            else if (obj.gameObject.CompareTag("Health"))
            {
                Destroy(obj.gameObject);
                ObjectOfInt.GetComponent<PlayerHealth>().GiveHealth(25);
            }
        }
        if (ObjectOfInt.gameObject.CompareTag("Enemy") && obj.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(obj.gameObject);
            ObjectOfInt.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
}
