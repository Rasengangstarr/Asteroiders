using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalCamera : MonoBehaviour
{

    public GameObject pointOfFocus;

    double distanceFromFocus;
   

    // Start is called before the first frame update
    void Start()
    {
        distanceFromFocus = Vector3.Distance(transform.position, pointOfFocus.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            pointOfFocus.transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
        }

        if(Input.GetKey(KeyCode.D))
        {
            pointOfFocus.transform.Rotate(0.0f, -1.0f, 0.0f, Space.World);
        }

        if(Input.GetKey(KeyCode.S))
        {
            pointOfFocus.transform.Rotate(1.0f, 0f, 0f, Space.World);
        }

        if(Input.GetKey(KeyCode.W))
        {
            pointOfFocus.transform.Rotate(-1.0f, 0f, 0f, Space.World);
        }

    }
}
