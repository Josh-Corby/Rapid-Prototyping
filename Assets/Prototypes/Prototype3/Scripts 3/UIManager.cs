using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Proto3
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public GameObject victoryScreen;

        private void Start()
        {
            victoryScreen.SetActive(false);
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