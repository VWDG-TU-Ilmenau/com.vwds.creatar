using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace vwds.CreatAR
{
    public class UserInput : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool isMouse;
        private Camera cam;
        private ARRaycastManager arRaycastManager;
        private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
        void Start()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
            cam = GetComponentInChildren<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isMouse)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {

                    Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Debug.Log("hit");
                        if (hit.transform.CompareTag("CreatARObject"))
                        {
                            // Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                            // hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                            CreatARObjectsManager.Instance.SelectObject(hit.transform.GetComponentInParent<CreatARObjBehaviour>().gameObject);
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Debug.Log("hit");
                        if (hit.transform.CompareTag("CreatARObject"))
                        {
                            // Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                            // hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                            CreatARObjectsManager.Instance.SelectObject(hit.transform.parent.gameObject);
                        }
                    }
                }
            }
        }
    }
}