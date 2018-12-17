using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordSystem : MonoBehaviour {

    public Text record;

	// Use this for initialization
	void Start () {
        float result = GameController.result_time;
        record.text = result.ToString("f2") + " sec";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
