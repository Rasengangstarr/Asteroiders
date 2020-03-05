using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = new Vector2 (0, 0);
    public Transform target;
    public float speed = 0.5f;

    public GameObject placeholderBuilding; 

    public GameObject cursorBuilding;

    public float rotateLerpSpeed = 16;

    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    bool zoomingToObject = false;

    bool focusedOnObject = false;

    void Start()
    {
        cursorBuilding = Instantiate(placeholderBuilding,new Vector3(-10000,-10000,-10000), Quaternion.identity) as GameObject;
        cursorBuilding.gameObject.tag="CursorBuilding";
        cursorBuilding.gameObject.AddComponent<CursorController>();
        
    }

    void FixedUpdate()
    {
        if (zoomingToObject) {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            
             var q = Quaternion.LookRotation(target.position - transform.position);
             transform.rotation = Quaternion.Lerp(transform.rotation, q, rotateLerpSpeed);

            if (Vector3.Distance(desiredPosition, transform.position) <= target.gameObject.GetComponent<Renderer>().bounds.size.x * 1.5f ) {
                zoomingToObject = false;
                focusedOnObject = true;
            }
        }
        
    }


  
    // Update is called once per frame
    void Update()
    {
        if (!zoomingToObject && !focusedOnObject)
        {
            if (Input.GetMouseButtonDown(0)){ // if left button pressed...
                Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)){
                    target =  hit.transform;
                    zoomingToObject = true;
                    //transform.LookAt(target);
                }
            }
                
            if (Input.GetMouseButton(1)){ // if right button pressed...
                rotation.y += Input.GetAxis ("Mouse X");
                rotation.x += -Input.GetAxis ("Mouse Y");
                transform.eulerAngles = (Vector2)rotation * speed;
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
            }
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
            }
        }
        else if (focusedOnObject) {

            transform.LookAt(target);

            if(Input.GetKey(KeyCode.A))
            {
                 transform.RotateAround (target.position, new Vector3 (0, 1, 0), 1);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.RotateAround (target.position, new Vector3 (0, 1, 0), -1);
            }
            if(Input.GetKey(KeyCode.W))
            {
                transform.RotateAround (target.position, new Vector3 (0, 0, 1), 1);
            }
            
            if(Input.GetKey(KeyCode.S))
            {
                transform.RotateAround (target.position, new Vector3 (0, 0, 1), -1);
            }

            if(Input.GetKey(KeyCode.Q))
            {
                focusedOnObject = false;
            }

            
            Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = 1 << 8;

            if (Physics.Raycast(ray, out hit, 100, layerMask) ){

                cursorBuilding.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);

                Quaternion wantedRotation = Quaternion.LookRotation(hit.normal);
                cursorBuilding.transform.rotation = wantedRotation;
                //cursorBuilding.transform.Rotate(90,90,90);

                if (Input.GetMouseButtonDown(0) && !cursorBuilding.GetComponent<CursorController>().Colliding){ // if left button pressed...
                    
                    var building = Instantiate(placeholderBuilding,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity);
                    wantedRotation = Quaternion.LookRotation(hit.normal);
                    building.transform.rotation = wantedRotation;
                    //building.transform.Rotate(90,90,90);
                    building.gameObject.layer = 9;
                }

            }
            else {
                cursorBuilding.transform.position =  new Vector3 (-10000, -10000, -10000);
            }
            
            
        }
    }
    
}
