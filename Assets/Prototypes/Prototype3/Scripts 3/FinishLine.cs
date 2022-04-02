using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto3
{
    public class FinishLine : GameBehaviour
    {
        public AudioSource AudioSource;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioSource.Play();
                _UI3.ToggleVictoryCanvas();
            }
        }
    }
}