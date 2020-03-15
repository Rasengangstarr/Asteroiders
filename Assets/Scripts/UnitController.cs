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
    void Update()
    {
        if (target != null) {
            MoveTowardsTarget();
        }
    }

    public void AssignNewTarget(EntityController newTarget) {
        target = newTarget;
    }

    protected void MoveTowardsTarget() {

        if(Vector3.Distance(other.position, transform.position) > target.ApproachBoundary) {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }
}
