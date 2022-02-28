using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proto1
{
    public class GameManager : GameBehaviour<GameManager>
    {
        Timer timer;
        
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


        public void Quit()
        {
            Application.Quit();
        }


        public void ToggleGameOver()
        {
            _UI1.ToggleGameOverCanvas();
            Time.timeScale = 0f;
            _S.GameOver();

            
        }
        public void Retry()
        {
            ToggleGameOver();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
