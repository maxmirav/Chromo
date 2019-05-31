using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    public GameObject moveThisBlock;

    void Start()
    {
        GetComponentInChildren<WaypointSystem>().enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponentInChildren<WaypointSystem>().enabled = true;
        }
        
    }
}
