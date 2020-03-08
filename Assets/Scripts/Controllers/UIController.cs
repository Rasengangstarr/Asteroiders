using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroiders {
    public class UIController : MonoBehaviour
    {
        public Text SelectedBuildingText;
        public Text KoboldOreText;

        GameObject highlightedBuilding;

        public void ChangeSelectedBuilding(GameObject gameObject){
            if (highlightedBuilding != null) {
                Destroy(highlightedBuilding.GetComponent<Outline>());
            }
            highlightedBuilding = gameObject;
            SelectedBuildingText.text = highlightedBuilding.GetComponent<BuildingController>().GetUITextName();
            highlightedBuilding.AddComponent<Outline>();
        }

        void Update() {
            KoboldOreText.text = GameGlobals.KoboldOre.ToString();
        }
    }
}
