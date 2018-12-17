using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject menu_ui;
    private bool pausing = false;

	// Use this for initialization
	void Start () {
        menu_ui.SetActive(false);
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pausing)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        

	}

    void Pause()
    {
        menu_ui.SetActive(true);
        Time.timeScale = 0;
        pausing = true;
    }

    void Resume()
    {
        menu_ui.SetActive(false);
        Time.timeScale = 1;
        pausing = false;
    }
}
