using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR
{
    public class CreatARObjectInfoButtonBehaviour : MonoBehaviour
    {
        public Vector3 Offset;
        private Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Canvas>().worldCamera;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(cam.transform);
            transform.Rotate(0f, 180f, 0f);
        }

        public void SnapToObject(GameObject obj)
        {
            Transform[] transforms = obj.GetComponentsInChildren<Transform>();
            transform.position = transforms[transforms.Length - 1].position;
        }
    }
}