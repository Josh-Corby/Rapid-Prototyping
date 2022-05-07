using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto5
{
    public class GameManager : GameBehaviour<GameManager>
    {
        public int intelCollected;
        public GameObject FinishLine;

        void Start()
        {
            intelCollected = 0;
            FinishLine.SetActive(false);
        }

        
        void Update()
        {
            if(intelCollected ==4)
            {
                FinishLine.SetActive(true);
            }
        }
    }
}