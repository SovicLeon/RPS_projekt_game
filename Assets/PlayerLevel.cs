using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{
    public static event Action OnPlayerLevelUp;
    public float level;
    public float levelUped;

    public PlayerLevelBar levelBar;
    void Start()
    {
        levelUped=1;
        level=0;
    }
    private void OnEnable() {
        EnemyHealth.OnEnemyDeath += KilledEnemy;
    }
    private void OnDisable() {
        EnemyHealth.OnEnemyDeath -= KilledEnemy;
    }
    public void KilledEnemy(){
        GetXp(20);
    }
    public void GetXp(float xp){
        level+=xp;
        levelBar.setLevel(level);
        if(level>=100){
            levelUped++;
            level=0;
            OnPlayerLevelUp?.Invoke();
            
        }
    }
}
