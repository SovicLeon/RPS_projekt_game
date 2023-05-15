using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
     public static event Action OnEnemyDeath;
    public float maxHealth =20;
    private float health;

    
    void Start()
    {
        health=maxHealth;
    }
   
    public void TakeDamage(float damage){
         health -= damage;
            if(health <= 0){
            health=0;
            Destroy(this.gameObject);
            OnEnemyDeath?.Invoke();
            
        }
    }
}
