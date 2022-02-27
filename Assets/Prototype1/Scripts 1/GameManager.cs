using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class GameManager : GameBehaviour<GameManager>
    { 
        private void Start()
        {
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (_SM.waveNumber >+20)
            {
                _SM.waveNumber = 20;
                _UI1.ToggleVictoryCanvas();
                


            }
        }
        //public void AddScore(int _score)
        //{
        //    score += _score;

        //}

        public void GameOver()
        {
            Time.timeScale = 0f;
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
