using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Proto1
{
    public class GameOver : GameBehaviour<GameOver>
    {

        public GameObject gameOverCanvas;
        public void ToggleGameOver()
        {
            gameOverCanvas.SetActive(true);

            if (gameOverCanvas.activeSelf)
            {
                Time.timeScale = 0f;

            }
        }
        public void Retry()
        {
            ToggleGameOver();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}