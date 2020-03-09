using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalCamera : MonoBehaviour
{

    public GameObject pointOfFocus;

    double distanceFromFocus;

    double xAngle = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        distanceFromFocus = Vector3.Distance(transform.position, pointOfFocus.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //

        var verticalaxis = transform.TransformDirection(transform.up);
        var horizontalaxis = transform.TransformDirection(transform.right);

        xAngle += 0.01;
        double yAngle = 0;
        if(Input.GetKey(KeyCode.W))
        {
            pointOfFocus.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.S))
        {
            pointOfFocus.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.A))
        {
            pointOfFocus.transform.Rotate(1.0f, 0f, 0f, Space.World);
        }

        if(Input.GetKey(KeyCode.D))
        {
            pointOfFocus.transform.Rotate(-1.0f, 0f, 0f, Space.World);
        }

        // if(Input.GetKey(KeyCode.A))
        // {
        //     transform.position -= transform.right * Time.deltaTime * 3f;
        // }
        // if(Input.GetKey(KeyCode.D))
        // {
        //     transform.position += transform.right * Time.deltaTime * 3f;
        // }
        // if(Input.GetKey(KeyCode.W))
        // {
        // if (transform.position.x > pointOfFocus.transform.position.x)
        //     transform.position -= transform.up * Time.deltaTime * 3f;
        // else
        //     transform.position += transform.up * Time.deltaTime * 3f;
        // }
        
        // if(Input.GetKey(KeyCode.S))
        // {
        //     if (transform.position.x > pointOfFocus.transform.position.x)
        //         transform.position += transform.up * Time.deltaTime * 3f;
        //     else
        //         transform.position -= transform.up * Time.deltaTime * 3f;
        // }

        // var xTranslation = Convert.ToSingle(distanceFromFocus*Math.Cos(10) + pointOfFocus.transform.position.x);
        // var yTranslation = Convert.ToSingle(distanceFromFocus*Math.Sin(10) + pointOfFocus.transform.position.y);

        //transform.position += transform.right * Time.deltaTime * 10;
        
        

        Vector3 relativePos = pointOfFocus.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;

        //transform.position += transform.forward * Time.deltaTime * yTranslation;
        // transform.position += transform.up * Time.deltaTime * xTranslation;
        
        // transform.position += transform.right * Time.deltaTime * xTranslation;

        

        // transform.LookAt(pointOfFocus.transform.position);
        //transform.position = new Vector3(xTranslation, yTranslation, 0);

       
    }
}
