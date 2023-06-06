using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMove playerMove;

    [SerializeField] GameObject projectilePrefab;

    private void Awake() {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update() {
        if (timer < timeToAttack) {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnProjectile();
    }

    private void SpawnProjectile() {
        GameObject projectileShot = Instantiate(projectilePrefab);
        projectileShot.transform.position = transform.position;
        
        // Set direction of the projectile
        if (playerMove.move) {
            projectileShot.GetComponent<ProjectileTrajectory>().SetDirection(playerMove.lastHorizontalVector, playerMove.lastVerticalVector);
        } else {
            projectileShot.GetComponent<ProjectileTrajectory>().SetDirection(0.0f, 1f);
        }

        // Set rotation of the projectile sprite
        Vector3 lookDirection = new Vector3(playerMove.lastHorizontalVector, playerMove.lastVerticalVector, 0);
        if (lookDirection != Vector3.zero) {
            projectileShot.transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        StartCoroutine(ChangeSpeedForDuration(newSpeed, 10f));
    }
private void OnEnable() {
        PlayerHealth.OnPlayerDeath += DisablePlayerShoot;
    }
   
    private void DisablePlayerShoot(){
       timeToAttack=9999999;
    }
    
    private IEnumerator ChangeSpeedForDuration(float newSpeed, float duration)
    {
        float originalSpeed = timeToAttack;
        timeToAttack = newSpeed;
        yield return new WaitForSeconds(duration);
        timeToAttack = originalSpeed;
    }
     public void UpgradeSpeed(float newSpeed)
    {
        timeToAttack += newSpeed;
    }
}
