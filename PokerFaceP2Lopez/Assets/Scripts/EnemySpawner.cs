using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    private GameObject Obstacle1Prefab;
   
    private GameObject Obstacle2Prefab;

    
    private float Obstacle1Interval = 3.5f;
    
    private float Obstacle2Interval = 5.5f;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Obstacle1Interval, Obstacle1Prefab));
        StartCoroutine(spawnEnemy(Obstacle2Interval, Obstacle2Prefab));

    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy)); 
    }
}
