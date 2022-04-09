using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Proto4
{
    public class AlgorithmDisplay : GameBehaviour
    {
        public Algorithm algorithm;
        public TMP_Text algorithmText;
 
        void Start()
        {
            algorithmText.text = algorithm.algorithm;
        }
    }
}