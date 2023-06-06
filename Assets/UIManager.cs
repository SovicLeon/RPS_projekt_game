using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
   public GameObject gameOverMenu;
   public GameObject Player;
    public GameObject Upgrades;
   public void EnableGameOverMenu(){
    gameOverMenu.SetActive(true);
      
      Upgrades.SetActive(false);
     }

       public void upgradeSpeedOfPlayer(){
         Upgrades.SetActive(false);
        
      if(Player.gameObject.CompareTag("Player")){
      Player.GetComponent<PlayerMove>().UpgradeSpeed((float)3);
     }
      
    }
    
     public void Nuke(){
      Upgrades.SetActive(false);
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
      foreach(GameObject target in gameObjects)
        GameObject.Destroy(target);
    }
 private void OnEnable()
{
    PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    LevelSystem.OnLevelUp += EnableUpgradeMenu;
}

private void OnDisable()
{
    PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    LevelSystem.OnLevelUp -= EnableUpgradeMenu;
}

 

private void EnableUpgradeMenu()
{
    Upgrades.SetActive(true);
    gameOverMenu.SetActive(false);
}

   public void RestartLevel(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void StartGame(){
      SceneManager.LoadScene("SampleScene");
   }
   public void GoToMainMenu(){
       SceneManager.LoadScene("MainMenu");
   }
     public void Exit(){
      Application.Quit();
   }
}
