using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public float[] growthPoint;
    public float[] salmonSizes;
    public GameObject[] salmonObjects;

    private GameObject Player;
    private int salmonID;
    private float growth = 0;

    [Range(0,1)] public float feedpoint = 0.1f;

    // Use this for initialization
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");

        salmonID = 0;
        Player.transform.localScale *= salmonSizes[salmonID]; 
    }

    // Update is called once per frame
    void Update()
    {

        if (growth >= 1)
        {
            ScaleChange();
            growth = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        if (other.tag == "Bite")
        {
            growth += feedpoint;
        }
    }

    void ScaleChange()
    {
        salmonID++;

        if (salmonID >= salmonSizes.Length)
        { 
            salmonID = 0;
        }

        for (var i = 0; i < salmonSizes.Length; i++)
        {
            if (i == salmonID)
            {
                Player.transform.localScale *= salmonSizes[salmonID];
            }
        }
    }


}




