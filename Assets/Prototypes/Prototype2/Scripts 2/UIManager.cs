using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Proto2
{
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text seedsText;

        public TMP_Text waveTimer;
        public TMP_Text waveCount;


        //fuction used to update the wave counter in the ui
        public void UpdateWaveCount(int _wave)
        {
            waveCount.text = "Wave: " + _GM2.waveCount.ToString();
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

    }
}
