using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proto1
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text waveCounter;
        public TMP_Text bestTime;
        public TMP_Text currentTimeText;
        public GameObject victoryScreen;
        public GameObject gameOverCanvas;


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

        public void ToggleGameOverCanvas()
        {
            gameOverCanvas.SetActive(true);

            if (gameOverCanvas.activeSelf)
            {
                
            }
        }

        public void UpdateCurrentTime(float _time)
        {
            currentTimeText.text = _time.ToString("F3");
        }

        public void UpdateScore(float _bestTime)
        {
            bestTime.text = _bestTime.ToString();
        }

        public void UpdateBestTime( float _time, bool _firstTime = false)
        {
            if (_firstTime)
                bestTime.text = "No Best Time Set Yet";
            else
                bestTime.text = "Best Time: " + _time.ToString("F3");
        }
    }
}