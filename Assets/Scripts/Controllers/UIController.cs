using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroiders {
    public class UIController : MonoBehaviour
    {
        public Text SelectedBuildingText;
        public Text KoboldOreText;

        public GameObject ConnectingLinePrefab;

        GameObject CursorConnectingLine;

        public bool ConnectingBuildings = false;

        GameObject highlightedBuilding;

        public void ChangeSelectedBuilding(GameObject gameObject){
            if (highlightedBuilding != null) {
                Destroy(highlightedBuilding.GetComponent<Outline>());
            }
            highlightedBuilding = gameObject;
            SelectedBuildingText.text = highlightedBuilding.GetComponent<BuildingController>().GetUITextName();
            highlightedBuilding.AddComponent<Outline>();
        }

        public void ConnectBuildings(GameObject building1, GameObject building2) {
            building1.GetComponent<BuildingController>().ConnectedBuildings.Add(building2);
            var line = Instantiate(ConnectingLinePrefab, new Vector3(-10000,-10000,-10000), Quaternion.identity);

            var linePoint1 = building1.transform.position;

            var linePoint2 = building2.transform.position;

            line.GetComponent<LineRenderer>().SetPosition(0, linePoint1);
            line.GetComponent<LineRenderer>().SetPosition(1, linePoint2);

        }

        void Start() {
            CursorConnectingLine = Instantiate(ConnectingLinePrefab,new Vector3(-10000,-10000,-10000), Quaternion.identity);
        }

        void Update() {
            KoboldOreText.text = GameGlobals.KoboldOre.ToString();
            if (ConnectingBuildings && highlightedBuilding != null) {
                
                var mousePosition = GetCurrentMousePosition().GetValueOrDefault();
                CursorConnectingLine.GetComponent<LineRenderer>().enabled = true;
                Debug.Log(" to " + highlightedBuilding.transform.position);
                CursorConnectingLine.GetComponent<LineRenderer>().SetPosition(0, mousePosition);
                CursorConnectingLine.GetComponent<LineRenderer>().SetPosition(1, highlightedBuilding.transform.position);

                int layerMask = 1 << 9;

                Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, layerMask)){
                    if (Input.GetMouseButtonDown(0)){
                        ConnectBuildings(highlightedBuilding, hit.transform.gameObject);
                    }
                }
            }
            else if (!ConnectingBuildings) {
                CursorConnectingLine.GetComponent<LineRenderer>().enabled = false;
            }
        }

        private Vector3? GetCurrentMousePosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var plane = new Plane(Vector3.forward, Vector3.zero);
    
            float rayDistance;
            if (plane.Raycast(ray, out rayDistance))
            {
                return ray.GetPoint(rayDistance);
                
            }
    
            return null;
        }
    }
}
