using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjs : MonoBehaviour
{
    
    public float spawnTime;
    public Transform[] spawnPos;
    public GameObject objToSpawn;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 0f, spawnTime);
    }

    void SpawnObjects()
    {
        GameObject spawnedObj;

        for (int i = 0; i < spawnPos.Length; i++)
        {
            
            spawnedObj = Instantiate(objToSpawn, spawnPos[i].transform.position, spawnPos[i].transform.rotation);
            spawnedObj.transform.position = gameObject.transform.position;
        }
    }

   
}
