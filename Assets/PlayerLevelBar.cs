using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLevelBar : MonoBehaviour
{
    public Slider slider;
    public Text lvl_obj;
    private int Level;
    
    public void setLevel(float level){
        slider.value = level;
    }
    private void OnEnable() {
        PlayerLevel.OnPlayerLevelUp += LevelUpText;
    }
    private void OnDisable() {
         PlayerLevel.OnPlayerLevelUp -= LevelUpText;
    }
    public void LevelUpText(){
        Level++;
        lvl_obj.text=Level.ToString();

    }
    private void Start() {
        Level=1;
        lvl_obj.text=Level.ToString();
    }


}
