using UnityEngine;

public class Master: MonoBehaviour {

    public Transform enemyPrefab;

    public float timeBeteweenWaves = 5f;
    private float countdown = 2f;
    
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
        Debug.Log("Wave Incoming");
    }
}
