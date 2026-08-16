using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	
	void Update () {
		
	}

    public void PlayGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");        
    }

    public void Option() {
        Debug.Log("Create a Option scene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
