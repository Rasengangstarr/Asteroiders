using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroiders {
    public class OreMinerController : BuildingController
    {
        public override string GetUITextName() {
            return "Ore Miner";
        }
        
        void Update() {
            GameGlobals.KoboldOre += 1;
        }
    }
}