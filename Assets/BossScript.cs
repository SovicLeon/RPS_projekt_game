using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject EnemySpawner;
    public GameObject BossSpawner;

    private void Start()
    {
        EnemySpawner.GameObject().SetActive(false);
        BossSpawner.GameObject().SetActive(false);
    }

}