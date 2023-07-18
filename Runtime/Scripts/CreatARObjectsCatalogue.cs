using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vwds.CreatAR
{
    [CreateAssetMenu(fileName = "New Objects Catalogue", menuName = "CreatAR/CreatAR Objects Catalogue", order = 1)]
    public class CreatARObjectsCatalogue : ScriptableObject
    {
        public List<CreatARObject> CreateARObjects;
    }
}