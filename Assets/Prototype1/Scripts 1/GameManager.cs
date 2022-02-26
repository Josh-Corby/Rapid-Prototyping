using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class GameManager : GameBehaviour<GameManager>
    {
        public int score;
        private void Start()
        {
            Time.timeScale = 1;
            score = 0;
        }

        public void AddScore(int _score)
        {
            score += _score;
            _UI.scoreText.text = score.ToString();
        }

        public void GameOver()
        {

        }
    }
}
