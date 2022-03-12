using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class Scoring : GameBehaviour<Scoring>
    {
        /// <summary>
        /// varuables and references
        /// </summary>
        public float currentTime;
        public float bestTime;
        Timer timer;

        private void Start()
        {
            timer = FindObjectOfType<Timer>();
            timer.StartTimer();

            /// if there is a best time already set in playerprefs and sets it to the best time in the script
            if (PlayerPrefs.HasKey("BestTime"))
            {
                bestTime = (PlayerPrefs.GetFloat("BestTime"));
                _UI1.UpdateBestTime(bestTime);
            }
            else
            {
                bestTime = 10000;
                _UI1.UpdateBestTime(bestTime, true);
            }
 
        }
        /// <summary>
        /// update the ui timer
        /// </summary>
        void Update()
        {
            if(timer.IsTiming())
            {
                _UI1.UpdateCurrentTime(timer.GetTime());
            }    
        }

        /// <summary>
        /// when the game is over, pause the timer and check if current time beats the best time, if so
        /// overwrite the best time
        /// </summary>
        public void GameOver()
        {
            timer.PauseTimer();
            currentTime = timer.GetTime();

            if(currentTime < bestTime)
            {
                bestTime = currentTime;
                PlayerPrefs.SetFloat("BestTime", bestTime);
            }
        }
    }
}