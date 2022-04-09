using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto4
{
    [CreateAssetMenu(fileName = "New Algorithm", menuName = "Algorithm")]
    public class Algorithm : ScriptableObject
    {
        public string algorithm;
        public int solution;
    }
}