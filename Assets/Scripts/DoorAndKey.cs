using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndKey : MonoBehaviour
{
    public Transform doorPos;
    private int current;
    public float keySpeed;
    public bool keyIsMoving;
    public bool isKey;
    public bool isDoor;
    public GameObject doorFx;
    public GameObject fxPos;

    // Start is called before the first frame update
    void Start()
    {
        
        keyIsMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyIsMoving)
        {
            MoveThisKey();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (isKey)
        {
            if (col.gameObject.tag == "Player")
            {
                keyIsMoving = true;
            }

            if (col.gameObject.tag == "Door")
            {
                keyIsMoving = false;
                Destroy(gameObject);

            }
        }




    }

    void MoveThisKey()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, doorPos.position, keySpeed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(pos);
    }







}
