using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace vwds.CreatAR.UI
{
    public class CreatARObjectButton : MonoBehaviour
    {
        public Image ObjectImage;
        public TextMeshProUGUI ObjectText;
        private CreatARObject creatARObjectRef;

        public void SetUpButton(CreatARObject creatARObject)
        {
            creatARObjectRef = creatARObject;

            ObjectImage.sprite = creatARObject.ObjectImage;
            ObjectText.text = creatARObject.ObjectName;
        }

        public void InstantiateObject()
        {
            CreatARObjectsManager.Instance.InstantiateObject(creatARObjectRef.ObjectPrefab);
        }
    }
}

