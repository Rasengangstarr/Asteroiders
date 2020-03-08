using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroiders {
    public class BuildingController : MonoBehaviour
    {
        public void Highlighted() {
            
        }

        public virtual string GetUITextName() {
            return "Unknown Object";
        }

    }
}