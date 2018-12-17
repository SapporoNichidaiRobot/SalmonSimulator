using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntensiveUI : MonoBehaviour {

    public Image BoostGage;
    Image intensiveLine;
    GameObject Player;
    Rigidbody rb;
    Color color = new Color(1, 1, 1, 0);

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
        intensiveLine = GetComponent<Image>();
        intensiveLine.color = color;
	}
	
	// Update is called once per frame
	void Update () { 
        if(GameController.isStarted){
        if (Input.GetKey(KeyCode.LeftShift) && BoostGage.fillAmount > 0)
        {
            if (color.a <= 1)
            {
                color.a += 0.75f;
            }
        }
        else
        {
            if (color.a > 0)
            {
                color.a -= 0.75f;
            }
        }

        intensiveLine.color = color;}
	}
}
