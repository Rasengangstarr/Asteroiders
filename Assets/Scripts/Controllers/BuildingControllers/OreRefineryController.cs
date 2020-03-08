using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroiders {
    public class OreRefineryController : BuildingController
    {
        public override string GetUITextName() {
            return "Ore Refinery";
        }

        void Update() {
            GameGlobals.KoboldIngots += 1;
        }
    }
}
