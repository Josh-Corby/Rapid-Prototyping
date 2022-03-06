using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proto1
{
    public class UIManager : GameBehaviour<UIManager>
    {
        /// <summary>
        /// References
        /// </summary>
        // public TMP_Text waveCounter;
        public TMP_Text bestTime;
        public TMP_Text currentTimeText;
        
        public GameObject gameOverCanvas;

        public GameObject victoryScreen;
        public TMP_Text score;
        public TMP_Text highscore;


        /// <summary>
        /// toggle victory canvas and pause the game
        /// </summary>
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

        /// <summary>
        /// toggle the game over canvas and pause the time
        /// </summary>
        public void ToggleGameOverCanvas()
        {
            gameOverCanvas.SetActive(true);

            if (gameOverCanvas.activeSelf)
            {
                
            }
        }

        /// <summary>
        /// update UI elements for the current time
        /// </summary>
        /// <param name="_time"></param>
        public void UpdateCurrentTime(float _time)
        {
            currentTimeText.text = _time.ToString("F3");
            score.text = "Your time: " + _time.ToString("F3");
    }

        /// <summary>
        /// update UI elements for best time
        /// </summary>
        /// <param name="_bestTime"></param>
        public void UpdateScore(float _bestTime)
        {
            bestTime.text = _bestTime.ToString();
            highscore.text = "Best Time: " + _bestTime.ToString();
        }

        /// <summary>
        /// Update the best time value and the respective UI elements
        /// </summary>
        /// <param name="_time"></param>
        /// <param name="_firstTime"></param>
        public void UpdateBestTime( float _time, bool _firstTime = false)
        {
            if (_firstTime)
                bestTime.text = "No Best Time Set Yet";
            else
            {
                bestTime.text = "Best Time: " + _time.ToString("F3");
                highscore.text = "Best Time: " + _time.ToString("F3");
            }
        }
    }
}