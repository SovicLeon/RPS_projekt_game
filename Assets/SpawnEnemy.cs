using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefab;
    public float respawnTime = 1.0f;
    public float spawnDistance = 5.0f;

    private void spawnEnemy() {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 spawnPos = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)) + playerPos;
        GameObject newEnemy = Instantiate(prefab, spawnPos, Quaternion.identity);
    }


    IEnumerator spawnCoroutine() {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            respawnTime=Random.Range(2f, 4f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }
}
