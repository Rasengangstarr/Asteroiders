using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalCamera : MonoBehaviour
{

    public GameObject pointOfFocus;

    double distanceFromFocus;

    public float fullyZoomedDistance = 13.5f;
    public double fullyZoomedXAngle = 90;
   

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

        float currentDistance = Vector3.Distance(transform.position, pointOfFocus.transform.position);

        float cameraRotationX = 90f / -Math.Abs(currentDistance - fullyZoomedDistance);
        
        var scrollWheelDelta = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollWheelDelta);
        if (cameraRotationX >= -90f || scrollWheelDelta < 0) {
            
            var myRotation = Quaternion.AngleAxis(cameraRotationX, Vector3.right);
            var myPosition = Vector3.MoveTowards(transform.position, pointOfFocus.transform.position, (scrollWheelDelta * 1f) * (currentDistance - fullyZoomedDistance));
            transform.SetPositionAndRotation(myPosition, myRotation);

        } 
    }
}
