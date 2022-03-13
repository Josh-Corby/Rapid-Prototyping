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

        public void UpdateSeedAmount(int _seeds)
        {
            seedsText.text = _seeds.ToString();
        }

    }
}
