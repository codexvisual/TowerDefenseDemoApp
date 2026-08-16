using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text moneyText;
    public Text livesText;

    public static int money;
    public int startMoney = 100;

    public static int lives;
    public int startingLives = 10;

	void Start () {
        money = startMoney;
        lives = startingLives;
	}
	
	void Update () {
        moneyText.text = "$" + money.ToString();
        livesText.text = "" + lives.ToString();
	}
}
