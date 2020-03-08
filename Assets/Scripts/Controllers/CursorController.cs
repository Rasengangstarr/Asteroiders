using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroiders {
    public class CursorController : MonoBehaviour
    {

        List <GameObject> currentCollisions = new List <GameObject> ();
    
        public bool Colliding = false;

        void Start() {
            Debug.Log("Instantialized");
        }

        void Update() {
            if (currentCollisions.Count > 0) {
                this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f, 0.3f);
                Colliding = true;
            }
            else {
                this.GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f, 0.3f);
                Colliding = false;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collode!");
            if (collision.gameObject.layer == 9) {
                currentCollisions.Add (collision.gameObject);
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.layer == 9) {
                currentCollisions.Remove (collision.gameObject);
            }
        }
    }
}