using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR
{
    public class CreatARObjBehaviour : MonoBehaviour
    {
        private CreatARStruct creatARObj;

        private void Start()
        {
            creatARObj = new CreatARStruct();
            creatARObj.Name = "New Name";
            creatARObj.Description = "New Description";
            UpdateTransform();
        }

        public string GetName()
        {
            return creatARObj.Name;
        }
        public string GetDescription()
        {
            return creatARObj.Description;
        }
        public void SetName(string newName)
        {
            creatARObj.Name = newName;
        }
        public void SetDescription(string newDescription)
        {
            creatARObj.Description = newDescription;
        }
        public void UpdateTransform()
        {
            creatARObj.Position = transform.position;
            creatARObj.Rotation = transform.eulerAngles;
            creatARObj.Scale = transform.localScale;
        }
    }
    public struct CreatARStruct
    {
        public string Name;
        public string Description;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
    }
}