using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedViewer : MonoBehaviour {

    public GameObject Player;
	
	// Update is called once per frame
	void Update () {

        var text = GetComponent<Text>();
        var rb = Player.GetComponent<Rigidbody>();

        text.text = rb.velocity.magnitude.ToString("F2") + "km/h";
	}
}
