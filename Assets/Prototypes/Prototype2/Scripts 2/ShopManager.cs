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
        public Image[] defenseTreesImages;
        public GameObject[] defenseTrees;
        public GameObject treeToBuild;

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

        public void TreeToBuild(int _tree)
        {
            for (int i = 0; i < defenseTrees.Length; i++)
            {
                if (_tree == i)
                {
                    treeToBuild = defenseTrees[_tree];
                    defenseTreesImages[_tree].color = Color.green;
                    Debug.Log(treeToBuild.name + " Selected");
                }
                else
                {
                    defenseTreesImages[i].color = Color.white;
                }
            }
        }
    }
}