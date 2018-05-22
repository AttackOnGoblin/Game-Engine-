
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 12f;

    public int health = 100;

    public int GainMoney = 30;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];

    }

    public void TakeDamage ( int amount )
    {
        health -= amount;

        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        PLayerStats.Money += GainMoney;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed*Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
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
        Destroy(gameObject);
    }
	
}
