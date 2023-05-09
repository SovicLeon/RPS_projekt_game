using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLevelBar : MonoBehaviour
{
    public Slider slider;
    public GameObject lvl_obj;
    TextMeshProUGUI level_text;
    public void setLevel(float level){
        slider.value = level;
    }
private void Start() {
    level_text=lvl_obj.GetComponent<TextMeshProUGUI>();
}

}
