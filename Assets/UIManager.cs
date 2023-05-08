using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
   public GameObject gameOverMenu;
   public void EnableGameOverMenu(){
    gameOverMenu.SetActive(true);
   }
   private void OnEnable() {
    PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
   }
   private void OnDisable() {
    PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
   }
   public void RestartLevel(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void GoToMainMenu(){

   }
     public void GoToShop(){
      
   }
}
