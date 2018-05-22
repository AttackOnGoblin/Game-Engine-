using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;

    public int damage = 50;

    public float explosionRadius = 0f;
    public GameObject hitEffect;

    public void chase (Transform _target)
    {
        target = _target;
    }
	
	
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitReg();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}
    void HitReg()
    {
        GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }
        

        Destroy(gameObject);

    }
    void Explode ()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        EnemyMovement e = enemy.GetComponent<EnemyMovement>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
