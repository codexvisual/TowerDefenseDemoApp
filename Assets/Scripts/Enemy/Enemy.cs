using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public static Enemy instance;

    public float speed;
    public float startSpeed = 10f;
    public float startHealth = 100;
    private float health;
    public int plusMoney = 20;

    public Image healthBar;

    public GameObject enemyDiedEffect;

    private bool isDead;

    public bool enemyDiedCount, isGameOver;

	void Start () {
        isDead = false;
        speed = startSpeed;
        health = startHealth;
        //MakeInstance();
    }

    void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead) {
            Die();
        }
    }

    public void Slow(float pct) {
        speed = startSpeed * (1f - pct);
    }

    void Die() {

        isDead = true;
       
        PlayerStats.money += plusMoney;

        GameObject diedEff = (GameObject)Instantiate(enemyDiedEffect, transform.position, transform.rotation);
        Destroy(diedEff, 0.5f);
        EnemyWave.enemiesLeft--;
        Destroy(gameObject);
    }

    void Update() {
        
        isGameOver = GameManager.instance.stopEnemy;

        if (isGameOver) {
            speed = GameManager.instance.updateEnemySpeed;
        }
                
    }
}
