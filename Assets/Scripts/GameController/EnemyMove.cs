using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour {

    private Transform target;
    private int wavePointIndex = 0;

    private Enemy enemy;

    public float rot1 = -90f,
        rot2 = -180f,
        rot3 = -90f,
        rot4 = 0f,
        rot5 = 90f,
        rot6 = 0f,
        rot7 = -90f,
        rot8 = 180f,
        rot9 = -90f,
        rot10 = -180f,
        rot11 = 90f,
        rot12 = -180f,
        rot13 = -90f,
        rot14 = 180f,
        rot15 = 90f,
        rot16,
        rot17,
        rot18,
        rot19,
        rot20,
        rot21;

    void Start () {
        target = Waypoints.waypoint[0];
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.waypoint.Length - 1)
        {
            EndPath();
           // Debug.Log("Enemy on the lose!");
            return;
        }

        wavePointIndex++;
        target = Waypoints.waypoint[wavePointIndex];

   
        if (wavePointIndex == 1) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot1, 0);
        }

        if (wavePointIndex == 2) {
            //float rot = -180f;
            enemy.transform.rotation = Quaternion.Euler(0, rot2, 0);
        }

        if (wavePointIndex == 3) {
          //  float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot3, 0);
        }

        if (wavePointIndex == 4) {
           // float rot = 0f;
            enemy.transform.rotation = Quaternion.Euler(0, rot4, 0);
        }

        if (wavePointIndex == 5) {
          //  float rot = 90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot5, 0);
        }

        if (wavePointIndex == 6) {
           // float rot = 0f;
            enemy.transform.rotation = Quaternion.Euler(0, rot6, 0);
        }

        if (wavePointIndex == 7) {
          //  float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot7, 0);
        }

        if (wavePointIndex == 8) {
           // float rot = 180f;
            enemy.transform.rotation = Quaternion.Euler(0, rot8, 0);
        }

        if (wavePointIndex == 9) {
           // float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot9, 0);
        }

        if (wavePointIndex == 10) {
           // float rot = -180f;
            enemy.transform.rotation = Quaternion.Euler(0, rot10, 0);
        }

        if (wavePointIndex == 11) {
          //  float rot = 90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot11, 0);
        }

        if (wavePointIndex == 12) { 
           // float rot = -180f;
            enemy.transform.rotation = Quaternion.Euler(0, rot12, 0);
        }

        if (wavePointIndex == 13) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot13, 0);
        }

        if (wavePointIndex == 14) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot14, 0);
        }

        if (wavePointIndex == 15) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot15, 0);
        }

        if (wavePointIndex == 16) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot16, 0);
        }

        if (wavePointIndex == 17) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot17, 0);
        }

        if (wavePointIndex == 18) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot18, 0);
        }

        if (wavePointIndex == 19) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot19, 0);
        }

        if (wavePointIndex == 20) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot20, 0);
        }

        if (wavePointIndex == 21) {
            //float rot = -90f;
            enemy.transform.rotation = Quaternion.Euler(0, rot21, 0);
        }

    }

    void EndPath()
    {
        PlayerStats.lives--;
        EnemyWave.enemiesLeft--;
        Destroy(gameObject);
    }
}
