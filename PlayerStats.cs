using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public Text moneyText;
    public Text roundText;
    public Text livesText;

	// Use this for initialization
	void Start () {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;

	}

    private void Update()
    {
        moneyText.text = Money.ToString();
        roundText.text = Rounds.ToString();
        livesText.text = Lives.ToString();
    }
}
