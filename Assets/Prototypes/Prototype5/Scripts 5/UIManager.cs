using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto5
{

    public class UIManager : GameBehaviour<UIManager>
    {
        public GameObject gameLoseUI;
        public GameObject gameWinUI;

        public GameObject killEnemyUI;
        bool gameIsOver;

        void Start()
        {
            Time.timeScale = 1f;
            Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        }


        void ShowGameWinUI()
        {
            OnGameOver(gameWinUI);
        }

        void ShowGameLoseUI()
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