using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR
{
    [CreateAssetMenu(fileName = "New Object", menuName = "CreatAR/CreatAR Object", order = 1)]
    public class CreatARObject : ScriptableObject
    {
        public string ObjectName;
        public Sprite ObjectImage;
        public GameObject ObjectPrefab;
    }
}