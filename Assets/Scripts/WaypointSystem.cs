using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public float startMovingTime;
    private int current;
    public bool spinner;
    
    void Start()
    {
        
        StartCoroutine(MoveObjects());
    }

    
    IEnumerator MoveObjects()
    {
        yield return new WaitForSeconds(startMovingTime);
        while (true)
        {
            yield return null;

            //Moves objects to waypoints
            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);


                    GetComponentInChildren<Rigidbody>().MovePosition(pos);

                
            }

            else
            {
                current = (current + 1) % target.Length;
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
