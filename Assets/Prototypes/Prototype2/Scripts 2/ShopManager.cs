using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Proto2
{
    public class ShopManager : GameBehaviour<ShopManager>
    {
        public Image[] defenseTreesBackground;
        public GameObject[] defenseTrees;
        public GameObject treeToBuild;

        private void Start()
        {
            treeToBuild = null;
            SetBackGroundColour();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TreeToBuild(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TreeToBuild(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TreeToBuild(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                TreeToBuild(3);
            }
        }

        public void SetBackGroundColour()
        {
            for (int i = 0; i < defenseTreesBackground.Length; i++)
            {
                defenseTreesBackground[i].color = Color.grey;
            }
        }
        public void TreeToBuild(int _tree)
        {
            for (int i = 0; i < defenseTrees.Length; i++)
            {
                if (_tree == i)
                {
                    treeToBuild = defenseTrees[_tree];
                    defenseTreesBackground[_tree].color = Color.green;
                    _UI2.UpdateSelectedTreeText();
                }
                else
                {
                    defenseTreesBackground[i].color = Color.grey;
                }
            }
        }
    }
}