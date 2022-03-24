using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Proto3
{

    public class Key : MonoBehaviour
    {
        public GameObject bridge;
        public Vector3 finalRotation;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                bridge.transform.DORotate(finalRotation, 1);
            }
        }
    }
}