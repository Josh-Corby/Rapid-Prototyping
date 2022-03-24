using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto3
{


    public class FinishLine : GameBehaviour
    {


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _UI3.ToggleVictoryCanvas();
            }
        }
    }
}