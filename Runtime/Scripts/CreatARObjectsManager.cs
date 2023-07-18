using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR
{
    public class CreatARObjectsManager : MonoBehaviour
    {
        public static CreatARObjectsManager Instance;
        public static List<GameObject> ColliderBoxObjects;
        public static GameObject SelectedObject;
        public static List<CreatARStruct> CreatARObjects;
        public CreatARObjectInfoButtonBehaviour ObjectInfoButton;
        private void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
            CreatARObjects = new List<CreatARStruct>();
            ColliderBoxObjects = new List<GameObject>();
        }
        public void InstantiateObject(GameObject creatARObjectPrefab)
        {
            GameObject createARObjectInstance = Instantiate(creatARObjectPrefab, transform);
        }
        public void ClearObjects()
        {
            foreach (var obj in ColliderBoxObjects)
            {
                Destroy(obj);
            }
            ObjectInfoButton.gameObject.SetActive(false);
            ColliderBoxObjects.Clear();
        }
        public void AddObject(GameObject newObject)
        {
            ColliderBoxObjects.Add(newObject);
            newObject.GetComponent<CreatARObjBehaviour>().UpdateTransform();
        }
        public void DeleteObject(GameObject objectToDelete)
        {
            ColliderBoxObjects.Remove(objectToDelete);
            Destroy(objectToDelete);
        }
        public void DeleteSelectedObject()
        {
            ColliderBoxObjects.Remove(SelectedObject);
            Destroy(SelectedObject);
            ObjectInfoButton.gameObject.SetActive(false);
        }
        public void SelectObject(GameObject objectToSelect)
        {
            SelectedObject = objectToSelect;
            ObjectInfoButton.gameObject.SetActive(true);
            ObjectInfoButton.SnapToObject(SelectedObject);
        }
    }
}