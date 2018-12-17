using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class FishBase : MonoBehaviour {
    
    GameObject StartPoint;

    public static float boostTime = 5.0f;
    public static float chargeTime = 10.0f;
    public static float healthPoint = 10.0f;
    public static float damagePoint = 5f;
    public static float phase = 0;

	// Use this for initialization
	void Start () {

        phase = 0;
        StartPoint = GameObject.FindGameObjectWithTag("StartPoint");
        //初期位置をスタートポイントに設定
        transform.position = StartPoint.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && !GameController.isStarted)
        {
            GameController.isStarted = true;
        }

	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Goal")
        {
            GoalSystem.isGoaled = false;
        }
    }

    
}
