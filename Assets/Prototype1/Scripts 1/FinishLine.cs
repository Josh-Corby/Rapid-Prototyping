using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class FinishLine : GameBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _UI1.ToggleVictoryCanvas();
            }
        }
    }
}