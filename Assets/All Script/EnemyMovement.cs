
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    public int startHealth = 100;
    private float health;

    public int GainMoney = 30;

    [Header("Unity")]
    public Image healthBar;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];
        health = startHealth;

    }

    public void TakeDamage ( int amount )
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;

        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        PLayerStats.Money += GainMoney;

        WaveSpawn.EnemiesAlive--;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed*Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length -1)
        {
            EndPath();
            return;
        }


        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

    }
		
    void EndPath()
    {
        PLayerStats.Life--;
        WaveSpawn.EnemiesAlive--;
        Destroy(gameObject);
    }
	
}
