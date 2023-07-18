using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace vwds.CreatAR.UI
{
    public class ObjectInfoDisplayBehaviour : MonoBehaviour
    {
        public TMP_InputField NameInputField;
        public TMP_InputField DescriptionInputField;
        private CreatARObjBehaviour currentObj;
        private void OnEnable()
        {
            currentObj = CreatARObjectsManager.SelectedObject.GetComponent<CreatARObjBehaviour>();
            getInfo();
        }
        private void getInfo()
        {
            NameInputField.text = currentObj.GetName();
            DescriptionInputField.text = currentObj.GetDescription();
        }
        public void SetInfo()
        {
            currentObj.SetName(NameInputField.text);
            currentObj.SetDescription(DescriptionInputField.text);
        }
    }
}