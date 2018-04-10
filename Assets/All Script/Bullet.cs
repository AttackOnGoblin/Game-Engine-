using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
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
	}
    void HitReg()
    {
        GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);

        Destroy(gameObject);

    }
}
