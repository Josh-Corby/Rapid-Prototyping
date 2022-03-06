using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proto1
{
    public class GameManager : GameBehaviour<GameManager>
    {
        public Timer timer;
        
        private void Start()
        {
            Time.timeScale = 1;
        }

        /*
        private void Update()
        {
            if (_SM.waveNumber > +20)
            {
                _SM.waveNumber = 20;
                _UI1.ToggleVictoryCanvas();
            }
        }
        */

        public void Quit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Game over function tells the UImanager to turn on the game over UI, pauses
        /// the time scale
        /// </summary>
        public void ToggleGameOver()
        {
            _UI1.ToggleGameOverCanvas();
            Time.timeScale = 0f;
           // _S.GameOver();

            
        }
        /// <summary>
        /// reloads the scene
        /// </summary>
        public void Retry()
        {
            ToggleGameOver();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
