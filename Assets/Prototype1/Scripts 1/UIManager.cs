using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proto1
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text waveCounter;
        public GameObject victoryScreen;

        private void Update()
        {
            waveCounter.text = _SM.waveNumber.ToString() +" / 20";
        }

        public void ToggleVictoryCanvas()
        {
            {
                victoryScreen.SetActive(!victoryScreen.activeSelf);

                if (victoryScreen.activeSelf)
                {
                    Time.timeScale = 0f;
                }

                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }
}