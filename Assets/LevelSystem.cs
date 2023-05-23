using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class LevelSystem : MonoBehaviour
{
   private int level;
   private int xp;
   private int xpToNextLvl;
    public PlayerLevelBar lvlBar;
    public static event Action OnLevelUp;
    public LevelSystem(){
        level =0;
        xp=0;
        xpToNextLvl=100;
    }
    
    private void OnEnable() {
        EnemyHealth.OnEnemyDeath +=onKill ;
    }
    private void OnDisable() {
        EnemyHealth.OnEnemyDeath  -=onKill ;
    }
    public void addXp(int value){
        xp+=value;
        if(xp>=xpToNextLvl){
            level++;
            xp-=xpToNextLvl;
            lvlBar.LevelUpText();
            OnLevelUp?.Invoke();
        }
        lvlBar.setXp(xp);
    }
    private void onKill(){
        addXp(20);
    }
}

 

