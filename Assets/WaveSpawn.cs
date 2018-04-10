using UnityEngine;

public class WaveSpawn : MonoBehaviour {

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBeteweenWaves = 5f;
    private float countdown = 2f;
    private int WaveNumber = 1;

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBeteweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    void SpawnWave()
    {
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
        }
        WaveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
    }
}


