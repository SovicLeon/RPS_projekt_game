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
    
    public void setXp(float xp){
        slider.value = xp;
    }
    
    public void LevelUpText(){
        Level++;
        lvl_obj.text=Level.ToString();
        slider.value=0;

    }
    private void Start() {
        Level=1;
        slider.maxValue=100;
        slider.value=0;
        lvl_obj.text=Level.ToString();
    }


}
