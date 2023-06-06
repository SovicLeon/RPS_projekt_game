using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHealthBoss : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    public float maxHealth = 20;
    private float health;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        health = maxHealth;
        spriteRenderer = transform.Find("enemy_ufo_boss_idle_0").GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Destroy(this.gameObject);
            OnEnemyDeath?.Invoke();
        }
        else
        {
            StartCoroutine(DamageFlash(0.2f));
        }
    }

    private IEnumerator DamageFlash(float flashDuration)
    {
        Color originalColor = spriteRenderer.color;
        // A lighter shade of red
        spriteRenderer.color = new Color(1f, 0.5f, 0.5f);
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}
