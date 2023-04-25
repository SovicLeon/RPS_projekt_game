using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float health,maxHealth =100;
    public PlayerHealthBar healthBar;
    void Start()
    {
        health=maxHealth;
        healthBar.setMaxHealth(health);
    }

    public void TakeDamage(float damage){
        health-=damage;
        healthBar.setHealth(health);
        if(health<=0){
            health=0;
            Debug.Log("You re dead");
            OnPlayerDeath?.Invoke();
            
        }
    }
    
}
