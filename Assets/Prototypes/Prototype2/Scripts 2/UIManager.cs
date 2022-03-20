using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Proto2
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text seedsText;
        public TMP_Text waveTimer;
        public TMP_Text waveCount;
        public TMP_Text treeSelectedText;
        public TMP_Text wavesSurvivedText;

        public Canvas gameOverCanvas;
        public Canvas victoryCanvas;
        public TMP_Text notEnoughSeeds;

        private void Start()
        {
            notEnoughSeeds.enabled = false;
            treeSelectedText.text = "";
            gameOverCanvas.enabled = false;
            victoryCanvas.enabled = false;
        }

        //fuction used to update the wave counter in the ui
        public void UpdateWaveCount(float _wave)
        {
            waveCount.text = "Wave: " + _GM2.waveCount.ToString() + " / 20";
        }

        //function used to update the timer in the ui
        public void UpdateTimer(float _time)
        {
            waveTimer.text = _GM2.waveTimer.ToString("F2");
        }

        public void UpdateSeedAmount(int _seeds)
        {
            seedsText.text = "Seeds: " + _seeds.ToString();
        }

        public void UpdateSelectedTreeText()
        {
            treeSelectedText.text = _SH.treeToBuild.name;
            treeSelectedText.DOFade(255f, 1f);
            treeSelectedText.DOFade(0f, 1.5f);
        }
        
        public void WavesSurvivedCount()
        {
            wavesSurvivedText.text = _GM2.waveCount.ToString();
        }

        public void ToggleGameOverCanvas()
        {
            Time.timeScale = 0f;
            gameOverCanvas.enabled = true;
            wavesSurvivedText.text = "Waves survived: " + (_GM2.waveCount - 1).ToString();
        }

        public void ToggleVictoryCanvas()
        {
            Time.timeScale = 0f;
            victoryCanvas.enabled = true;
        }
    }
}