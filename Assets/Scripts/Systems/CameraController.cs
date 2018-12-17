using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouse_x = Input.GetAxis("Mouse X");
            transform.RotateAround(player.transform.position, transform.up, mouse_x);

        }
        transform.LookAt(player.transform);
    }
}
