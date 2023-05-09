using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{
    public static event Action OnPlayerLevelUp;
    public float level;
    public PlayerLevelBar levelBar;
    void Start()
    {
        level=1;
    }

    public void GetXp(float xp){
        level+=xp;
        levelBar.setLevel(level);
        if(level>=100){
            level=0;
            OnPlayerLevelUp?.Invoke();
            
        }
    }
}
