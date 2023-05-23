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

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        health=maxHealth;
        healthBar.setMaxHealth(health);

        // Fetch the SpriteRenderer from the child object
        spriteRenderer = transform.Find("player_spaceship_moving_0").GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Failed to find SpriteRenderer on child object.");
        }
    }

    private IEnumerator DamageFlash(float flashDuration)
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.setHealth(health);
        
        if (spriteRenderer != null)
        {
            StartCoroutine(DamageFlash(0.1f));
        }

        if(health <= 0)
        {
            health=0;
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
    }

    public void FixedUpdate()
    {
        Debug.Log(health);
    }

    public void GiveHealth(float newHealth)
    {
        if((health + newHealth) >= 100)
        {
            health = maxHealth;
        }
        else
        {
            health += newHealth;   
        }
        healthBar.setHealth(health);
    }
}
