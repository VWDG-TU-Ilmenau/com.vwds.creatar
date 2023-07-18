using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace vwds.CreatAR
{
    public class UIGroundControllerBehaviour : MonoBehaviour
    {
        public GameObject GroundInstance;
        public TextMeshProUGUI GroundHeightText;
        private Slider slider;
        private float changeValue;
        private float startValue;
        private bool isReset;
        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponent<Slider>();
        }
        // Update is called once per frame
        void Update()
        {
            if (isReset)
            {
                resetting();
            }
        }
        public void StartDragging()
        {
            startValue = GroundInstance.transform.position.y;
            isReset = false;
        }
        public void UpdateGround()
        {
            changeValue = startValue + slider.value - 0.5f;
            GroundInstance.transform.position = new Vector3(GroundInstance.transform.position.x, changeValue, GroundInstance.transform.position.z);
            GroundHeightText.text = ((int)(GroundInstance.transform.position.y * 100f)).ToString() + "cm";
        }
        public void Reset()
        {
            isReset = true;
        }
        private void resetting()
        {
            if (slider.value > 0.52f)
            {
                slider.value = slider.value - 0.05f;
            }
            else
            {
                if (slider.value < 0.45f)
                {
                    slider.value = slider.value + 0.05f;
                }
            }

            if (slider.value <= 0.052 && slider.value >= 0.45)
            {
                slider.value = 0.5f;
                isReset = false;
            }
        }
    }
}