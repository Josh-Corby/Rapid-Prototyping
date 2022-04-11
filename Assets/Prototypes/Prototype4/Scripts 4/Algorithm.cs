using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Proto4
{
    [CreateAssetMenu(fileName = "New Algorithm", menuName = "Algorithm")]
    public class Algorithm : ScriptableObject
    {
        public string algorithm;
        public int solution;
    }
}