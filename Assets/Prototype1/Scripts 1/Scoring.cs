using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class Scoring : GameBehaviour<Scoring>
    {
        public float currentTime;
        public float bestTime;
        Timer timer;

        private void Start()
        {
            timer = FindObjectOfType<Timer>();
            timer.StartTimer();

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
        void Update()
        {
            if(timer.IsTiming())
            {
                _UI1.UpdateCurrentTime(timer.GetTime());
            }    
        }

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