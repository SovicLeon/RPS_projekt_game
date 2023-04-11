using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefab;
    public float respawnTime = 1.0f;
    public float spawnYCoord = 1.3f;

    private void spawnEnemy() {
        GameObject newEnemy = Instantiate(prefab) as GameObject;
        newEnemy.transform.position = new Vector2(0.969038f, spawnYCoord);
        spawnYCoord += 0.2f;
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
