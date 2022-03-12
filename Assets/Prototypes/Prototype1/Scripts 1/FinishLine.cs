using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class FinishLine : GameBehaviour
    {
        // Checks if the player collides with the finish line and toggles the end game function
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _UI1.ToggleVictoryCanvas();
            }
        }
    }
}