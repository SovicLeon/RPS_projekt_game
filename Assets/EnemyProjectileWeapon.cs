using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    [SerializeField] GameObject enemyProjectilePrefab;

    private void Update() {
        if (timer < timeToAttack) {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnProjectile();
    }

    private void SpawnProjectile() {
        GameObject projectileShot = Instantiate(enemyProjectilePrefab);
        projectileShot.transform.position = transform.position;

        // Find the player game object
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Calculate direction vector from enemy to player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        
        // Set direction of the projectile
        projectileShot.GetComponent<ProjectileTrajectory>().SetDirection(directionToPlayer.x, directionToPlayer.y);

        // Set rotation of the projectile sprite
        Vector3 lookDirection = directionToPlayer;
        if (lookDirection != Vector3.zero) {
            projectileShot.transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
        }
    }


    public void ChangeSpeed(float newSpeed)
    {
        StartCoroutine(ChangeSpeedForDuration(newSpeed, 20f));
    }

    private IEnumerator ChangeSpeedForDuration(float newSpeed, float duration)
    {
        float originalSpeed = timeToAttack;
        timeToAttack = newSpeed;
        yield return new WaitForSeconds(duration);
        timeToAttack = originalSpeed;
    }
}
