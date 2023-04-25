using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float health,maxHealth;
    void Start()
    {
        health=maxHealth;
    }

    public void TakeDamage(float damage){
        health-=damage;
        if(health<=0){
            health=0;
            Debug.Log("You re dead");
            OnPlayerDeath?.Invoke();
            
        }
    }
    
}
