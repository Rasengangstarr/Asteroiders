using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController : EntityController
{
    protected bool canBuild;
    protected bool canHaul;

    protected float movementSpeed;
    protected float haulCapacity;

    protected EntityController target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (target != null) {
            SnapToTerrain();
        //}
    }

    public void AssignNewTarget(EntityController newTarget) {
        target = newTarget;
    }

    protected void SnapToTerrain(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit)) {
            //transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);
            var wantedRotation = Quaternion.LookRotation(hit.normal);
            transform.rotation = wantedRotation * Quaternion.Euler(90, 0, 0);
            var distanceToGround = hit.distance;
            GetComponent<AIPath>().gravity = new Vector3(-hit.point.x, -hit.point.y, -hit.point.z);
        }
    }

}
