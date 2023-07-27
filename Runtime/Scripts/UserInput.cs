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
        void Start()
        {
            cam = FindObjectOfType<ARCameraManager>().GetComponent<Camera>();
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
                        if (hit.transform.CompareTag("CreatARObject"))
                        {
                            CreatARObjectsManager.Instance.SelectObject(hit.transform.parent.gameObject);
                        }
                    }
                }
            }
        }
    }
}