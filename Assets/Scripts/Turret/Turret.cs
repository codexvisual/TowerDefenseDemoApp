using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    private Enemy targetEnemy;


    [Header("Attributes")]

    public float turretRange = 15f;   
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Set Up Field")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;

    [Header("Shooting")]
    public Animator anim;
    public GameObject bullet;
    public Transform firePoint;

    [Header("Laser")]
    public bool uselaser = false;
    public LineRenderer lineRenderer;

    public int damageOverTime = 30;
    public float slowdown = 0.5f;

    public GameObject laserImpact;


	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance) {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= turretRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else {
            target = null;
        }
    }

	void Update () {
        if (target == null) {
            anim.SetBool("Fire", false);
            if (uselaser) {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }
            
        LockOnTarget();

        if (uselaser)
        {
            Laser();
        }
        else {
            if (fireCountdown <= 0f) {
                
                ShootEnemy();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }        
    }

    void LockOnTarget() {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser() {

        targetEnemy.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowdown);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        laserImpact.transform.position = target.position + dir.normalized;
        laserImpact.transform.rotation = Quaternion.LookRotation(dir);
    }

    void ShootEnemy() {
        GameObject bulletFire = (GameObject) Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bullets = bulletFire.GetComponent<Bullet>();

        if (bullets != null) {
            anim.SetBool("Fire", true);
            bullets.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
