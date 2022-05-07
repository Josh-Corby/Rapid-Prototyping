using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proto5
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public GameObject gameLoseUI;
        public GameObject gameWinUI;
        public GameObject InteractionPanel;
        public TMP_Text InteractionText;
        public TMP_Text IntelAmountText;
        bool gameIsOver;

        void Start()
        {
            InteractionText.enabled = false;
            InteractionTextToggle(false);
            Time.timeScale = 1f;
            Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;          
        }

        public void IntelCollectedUI(int intelAmount)
        {
            IntelAmountText.text = ("Intel Collected: " + intelAmount + " / 4");
        }

        public void InteractionTextToggle(bool toggle)
        {
            if (toggle == true)
            {
                InteractionPanel.SetActive(true);
                InteractionText.enabled = true;
            }
            if (toggle == false)
            {
                InteractionPanel.SetActive(false);
                InteractionText.enabled = false;
            }
        }

        public void KillEnemyUI()
        {  
            InteractionText.text = "E: Kill Enemy";
        }

        public void IntelUI()
        {
            InteractionText.text = "E: Collect Intel";
        }

        public void ShowGameWinUI()
        {
            OnGameOver(gameWinUI);
        }

        public void ShowGameLoseUI()
        {
            OnGameOver(gameLoseUI);
        }

        void OnGameOver(GameObject gameOverUI)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            gameIsOver = true;
            Guard.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        }
    }
}