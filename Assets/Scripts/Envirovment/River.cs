using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour {

    private GameObject Player;

    public float river_speed = 1000;//川の速度(km)
    public bool river_forward = true;//川による加速方向

    // Use this for initialization
    void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (GameController.isStarted)
        {
            //Acceleration by river
            AccelerateByRiver(river_speed, river_forward);
        }
    }

    void AccelerateByRiver(float speed, bool forward)
    {
        var rb = Player.GetComponent<Rigidbody>();
        var target_velocity = Vector3.forward * speed;

        if (forward)
        {
            rb.AddRelativeForce(target_velocity * rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
        }
        else
        {
            rb.AddRelativeForce(target_velocity * -rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
        }
    }
}
