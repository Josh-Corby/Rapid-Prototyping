using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class BuildZone : GameBehaviour
    {
        public GameObject DefenseTreePrefab;
        public Transform buildPosition;

        public void BuildTree()
        {
            Instantiate(DefenseTreePrefab, buildPosition.transform);
        }
    }
}