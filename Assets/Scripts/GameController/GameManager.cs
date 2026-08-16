using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Transform explosionPoint;

    public GameObject gameOverPanel, settingsPanel, pausePanel, completeLevelPanel;
    public GameObject gameOverExplosion, base1, base2, base3;

    public Button pauseB, resumeB;

    public static bool gameEnded;
    public bool stopEnemy;

    public float updateEnemySpeed;

	void Start () {
        Time.timeScale = 1f;
        stopEnemy = false;
        gameEnded = false;
        resumeB.interactable = false;
        MakeInstance();
    }

    void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }
	
	void Update () {

        if (gameEnded) {
            return;
        }
        
        if (stopEnemy) {
            updateEnemySpeed = 0;            
        }
        
        if (PlayerStats.lives <= 0) {
            PlayerStats.lives = 0;      

            Instantiate(gameOverExplosion, explosionPoint.position, explosionPoint.rotation);

            StartCoroutine(DestroyBase());
            StartCoroutine(EndGame());
            StartCoroutine(StopTime());
        }
	}

    IEnumerator DestroyBase() {
        yield return new WaitForSeconds(0.3f);
        stopEnemy = true;
        base1.SetActive(false);
        base2.SetActive(false);
        base3.SetActive(false);
    }

    IEnumerator EndGame() {
        yield return new WaitForSeconds(2f);
        gameEnded = true;
        gameOverPanel.SetActive(true);
        Debug.Log("Game is Over!");
    }

    IEnumerator StopTime() {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }

    public void PauseGame() {
        pauseB.interactable = false;
        resumeB.interactable = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        resumeB.interactable = false;
        pauseB.interactable = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Retry() {
        string loadScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main");
    }

    public void Settings() {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }

    public void CancelSettings() {
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
    }

    public void SaveSettings() {
        Time.timeScale = 1f;
    }

    public void NextLevel() {
        Debug.Log("Next level unavailable");
    }

    public void GameWin() {
        gameEnded = true;
        Debug.Log("Level Completed!");
        StartCoroutine(CompleteLevel());
    }

    IEnumerator CompleteLevel() {
        yield return new WaitForSeconds(1.5f);
        completeLevelPanel.SetActive(true);
    }
}
