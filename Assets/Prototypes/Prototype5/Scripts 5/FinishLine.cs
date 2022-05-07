using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto5
{

    public class FinishLine : GameBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _UI5.ShowGameWinUI();
            }
        }
    }
}