using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 10f;

    public GameObject particle;

    public float explosionRadius;

    public int damageToEnemy = 50;

    public void Seek(Transform _target) {
        target = _target;
    }

	void Start () {
		
	}
	
	void Update () {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);
	}

    void HitTarget() {
        GameObject part = (GameObject) Instantiate(particle, transform.position, transform.rotation);
        Destroy(part, 0.3f);

        if (explosionRadius > 0f)
        {
            Explode();
        }

        else
        {
            Damage(target);
        }

        Destroy(gameObject);        
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) {
            e.TakeDamage(damageToEnemy);
        }
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
