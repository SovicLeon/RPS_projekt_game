using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Upgrades;

    private void OnEnable() {
    LevelSystem.OnLevelUp += EnableUpgradeMenu;
   }
   private void OnDisable() {
     LevelSystem.OnLevelUp -= EnableUpgradeMenu;
   }
     public void EnableUpgradeMenu(){
        Upgrades.SetActive(true);
     }
    public void upgradeSpeedOfPlayer(){
      if(Player.gameObject.CompareTag("Player")){
      Player.GetComponent<PlayerMove>().UpgradeSpeed((float)5);
     }
      
    }
     public void upgradeSpeedOfGun(){
     if(Player.gameObject.CompareTag("Player")){
      Player.GetComponent<ProjectileWeapon>().UpgradeSpeed((float)5);
     }
    }
     public void Nuke(){
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
      foreach(GameObject target in gameObjects)
        GameObject.Destroy(target);
    }
}
