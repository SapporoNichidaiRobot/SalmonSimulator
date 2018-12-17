using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private GameObject mainUI;
    private float count_time = 0;

    public static float result_time = 0;
    public static bool isClear;
    public static bool isFailed;
    public static bool isStarted;

    public string clearMessage;
    public string gameOverMessage;
    public GameObject gameResultUI;
    public GameObject startScreen;
    public GameObject gameOverButton;
    public GameObject gameClearButton;
    public Text resultText;
    public Text timer;

    // Use this for initialization
    void Start () {

        Time.timeScale = 1;

        mainUI = GameObject.FindGameObjectWithTag("MainUI");

        isStarted = false;
        isClear = false;
        isFailed = false;

        startScreen.SetActive(true);
        gameResultUI.SetActive(false);
        mainUI.SetActive(true);
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {

        if (isStarted)
        {
            count_time += Time.deltaTime;
            if (timer != null)
            {
                timer.text = count_time.ToString("f2") + "sec";
            }

            startScreen.SetActive(false);
        }

        if (isFailed)
        {
            GameOver();
        }
    }

    public static float getRecord()
    {
        return result_time;
    }

    void GameOver()
    {

        gameResultUI.SetActive(true);

        gameOverButton.SetActive(true);
        gameClearButton.SetActive(false);

        resultText.text = gameOverMessage;

        Time.timeScale = 0;
    }

    void GameClear()
    {
        mainUI.SetActive(true);
        gameResultUI.SetActive(true);
        result_time = count_time;



        Time.timeScale = 0;
    }
}
