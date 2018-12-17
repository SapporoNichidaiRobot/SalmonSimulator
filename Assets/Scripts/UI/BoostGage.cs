using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostGage : MonoBehaviour {

    Image _boostGage;
    float countTime;
    float chargeTime;

	// Use this for initialization
	void Start () {
        _boostGage = GetComponent<Image>();
        countTime = FishBase.boostTime;
        chargeTime = FishBase.chargeTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) && GameController.isStarted && _boostGage.fillAmount > 0) {

                _boostGage.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }else if (!Input.GetKey(KeyCode.LeftShift) && GameController.isStarted && _boostGage.fillAmount < 1) 
        {
            _boostGage.fillAmount += 1.0f / chargeTime * Time.deltaTime;
        }

    }
}
