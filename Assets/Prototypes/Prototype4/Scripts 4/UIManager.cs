using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Proto4
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text playerHP;
        public TMP_Text timerText;
        public Canvas gameCanvas;
        public Canvas menuCanvas;
        public Canvas gameOverCanvas;

        private void Start()
        {
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            menuCanvas.enabled = true;
        }

        private void Update()
        {
            timerText.text = "Time left: " + _GM4.timer.ToString("F3");
        }
        public void UpdatePlayerHPText()
        {
            playerHP.text = _P4.health.ToString();
        }

        public void StartGame()
        {
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
        }

        public void GameOver()
        {
            gameOverCanvas.enabled = true;
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;
        }
    }
}