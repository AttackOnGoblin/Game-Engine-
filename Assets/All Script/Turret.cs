using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target;
    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform Rotation;
    public float TurnSpeed = 7f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    
    

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy <shortestDist)
            {
                shortestDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else target = null;



    }
	
	void Update () {
        if (target == null)
            return;
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(Rotation.rotation,lookRotation,Time.deltaTime*TurnSpeed).eulerAngles;
        Rotation.rotation = Quaternion.Euler (0f, rotation.y,0f);

        if(fireCountdown <=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
	}

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.chase(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
