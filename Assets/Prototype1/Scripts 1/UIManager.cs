using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proto1
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text scoreText;
        public void UpdateScore(int _score)
        {
            scoreText.text = "Score: " + _score;
        }
    }
}