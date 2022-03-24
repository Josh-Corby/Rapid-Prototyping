using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto3
{
    public class BridgeControl : MonoBehaviour
    {
        public RotatingObject rotatingObject;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                rotatingObject.canSpin = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            rotatingObject.canSpin = false;
        }
    }
}