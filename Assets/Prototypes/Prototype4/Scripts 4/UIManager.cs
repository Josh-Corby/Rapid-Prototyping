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
        public GameObject gamePanel;
        public GameObject algorithmPanel;
        public GameObject gameOverPanel;
        public GameObject victoryPanel;
        public GameObject difficultyPanel; 

        private void Start()
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(false);
            algorithmPanel.SetActive(true);
            victoryPanel.SetActive(false);
            difficultyPanel.SetActive(false);
        }

        private void Update()
        {
            timerText.text = "Time : " + _GM4.timer.ToString("F3");
        }
        public void UpdatePlayerHPText()
        {
            playerHP.text = _P4.health.ToString();
        }

        public void ChooseDifficulty()
        {
            algorithmPanel.SetActive(false);
            difficultyPanel.SetActive(true);
        }
        public void StartGame()
        {
            difficultyPanel.SetActive(false);
            gamePanel.SetActive(true);
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
            gamePanel.SetActive(false);
        }

        public void Victory()
        {
            victoryPanel.SetActive(true);
            gamePanel.SetActive(false);
        }
    }
}