using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  
    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);  
        GameObject prefabToSpawn = enemyPrefabs[index];

        float x = Random.Range(-7f, 7f);
        Vector3 spawnPos = new Vector3(x, 6f, 0f); 

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
