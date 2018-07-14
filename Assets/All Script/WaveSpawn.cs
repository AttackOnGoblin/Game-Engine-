using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;
  

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text WaveCountdownText;

    public GameManager gameManager;

    private int WaveNumber = 0;

    void Start()
    {
        EnemiesAlive = 0;   
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (WaveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("Next Wave: {0:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PLayerStats.Wave++;

        Wave wave = waves[WaveNumber];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds (1f/wave.rate);
        }
        WaveNumber++;

        
      
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
    }
}


