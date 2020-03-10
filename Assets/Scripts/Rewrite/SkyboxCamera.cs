using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkyboxCamera : MonoBehaviour {


    // set the main camera in the inspector
    public Camera MainCamera;

    // set the sky box camera in the inspector
    public Camera SkyCamera;

    // the additional rotation to add to the skybox
    // can be set during game play or in the inspector
    public Vector3 SkyBoxRotation;

    // Use this for initialization
    void Start()
    {
        if (SkyCamera.depth >= MainCamera.depth)
        {
            Debug.Log("Set skybox camera depth lower "+
                " than main camera depth in inspector");
        }
        if (MainCamera.clearFlags != CameraClearFlags.Nothing)
        {
            Debug.Log("Main camera needs to be set to dont clear" +
                "in the inspector");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            SkyCamera.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.D))
        {
            SkyCamera.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.S))
        {
            SkyCamera.transform.Rotate(-1.0f, 0f, 0f, Space.Self);
        }

        if(Input.GetKey(KeyCode.W))
        {
            SkyCamera.transform.Rotate(1.0f, 0f, 0f, Space.Self);
        }
    }
}
