using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotSpeed;
    public bool rotateLeft;
    public bool rotateRight;
    public bool rotateForwards;
    public bool rotateBackwards;


    void FixedUpdate()
    {
        if (rotateLeft)
        {
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }

        if (rotateRight)
        {
            transform.Rotate(-(Vector3.forward) * rotSpeed * Time.deltaTime);
        }

        if (rotateForwards)
        {
            transform.Rotate(-(Vector3.right) * rotSpeed * Time.deltaTime);
        }

        if (rotateBackwards)
        {
            transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
        }
    }


}
