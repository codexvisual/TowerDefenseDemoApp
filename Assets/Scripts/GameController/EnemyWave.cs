using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWave : MonoBehaviour {

    public static int enemiesLeft = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    private int waveNum = 0;

    public GameManager gameManager;

    [SerializeField]
    public Text waveSize, waveLeft;

    void Start () {
        enemiesLeft = 0;
    }
	
	void Update () {

        if (enemiesLeft > 0) {
            return;
        }

        if (waveNum == waves.Length) {
            gameManager.GameWin();
            this.enabled = false;
        }

        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            Debug.Log("Spawn Enemy");
            return;
        }

        countdown -= Time.deltaTime;

        waveSize.text = " " + waves.Length;
        waveLeft.text = " " + waveNum; 
    }

    IEnumerator SpawnWave() {

        Wave wave = waves[waveNum];

        enemiesLeft = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemies(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveNum++;
    }

    void SpawnEnemies(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);       
    }
}
