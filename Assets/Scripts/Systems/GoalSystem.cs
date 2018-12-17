using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSystem : MonoBehaviour {

    public static bool isGoaled;

    public GameObject gameController;
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject mainUI;

	// Use this for initialization
	void Start () {

        isGoaled = false;

	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StageClear();
        }
    }

    void StageClear()
    {
        mainUI.SetActive(true);
        gameClearUI.SetActive(true);

        Time.timeScale = 0;
    }
}
