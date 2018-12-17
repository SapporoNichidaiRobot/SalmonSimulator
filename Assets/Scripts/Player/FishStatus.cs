using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishStatus : MonoBehaviour {

    
    private float healthPoint;
    private float damagePoint;
    private Slider hpGage;
    private GameObject gameController;

	// Use this for initialization
	void Start () {

        healthPoint = FishBase.healthPoint;
        damagePoint = FishBase.damagePoint;
        hpGage = GameObject.FindGameObjectWithTag("HPGage").GetComponent<Slider>();
        gameController = GameObject.FindGameObjectWithTag("GameController");

        hpGage.value = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if(healthPoint <= 0)
        {
            Debug.Log("HP is 0");
            GameController.isFailed = true;
        }

	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            healthPoint -= damagePoint;
            hpGage.value = healthPoint / FishBase.healthPoint;

        }
    }
}
