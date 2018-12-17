using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonController : MonoBehaviour {

    public bool isRiverClear = false;
    public GameObject Button_Ocean;

    private GameObject _child;

	// Use this for initialization
	void Start () {
        _child = Button_Ocean.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        var btn = Button_Ocean.GetComponent<Button>();

        if (isRiverClear)
        {
            Button_Ocean.GetComponent<Image>().color = Color.white;
            btn.enabled = true;
            _child.GetComponent<Text>().text = "Stage 海";
        }
        else
        {
            Button_Ocean.GetComponent<Image>().color = Color.gray;
            btn.enabled = false;
            _child.GetComponent<Text>().text = "-- Locked --";
        }
	}
}
