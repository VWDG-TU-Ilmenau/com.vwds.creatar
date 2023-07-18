using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR.UI
{
    public class CreatARObjectsMenu : MonoBehaviour
    {
        public CreatARObjectsCatalogue CreatARObjectsCatalogue;
        public GameObject CreatARObjectUIButton;
        public GameObject ContentContainer;
        public GameObject ContentView;
        public Sprite CloseView;
        public Sprite OpenView;
        private bool isInitialized;
        private bool isViewToggled;
        void Awake()
        {
            if (CreatARObjectsCatalogue != null)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            isInitialized = true;
            foreach(var creatARObject in CreatARObjectsCatalogue.CreateARObjects)
            {
                GameObject currentButton = Instantiate(CreatARObjectUIButton, ContentContainer.transform);
                currentButton.GetComponent<CreatARObjectButton>().SetUpButton(creatARObject);
            }
        }

        public void ToggleObjectsView()
        {
            isViewToggled = !isViewToggled;
            ContentView.SetActive(isViewToggled);
        }
    }
}