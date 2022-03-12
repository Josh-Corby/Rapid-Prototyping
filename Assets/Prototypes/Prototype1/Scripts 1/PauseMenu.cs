using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proto1
{

    public class PauseMenu : GameBehaviour
    {
        public GameObject ui;

        /*
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }
        }
        */

        /// <summary>
        /// function to toggle a ui on or off and change the timescale accordingly
        /// </summary>
        public void Toggle()
        {
            ui.SetActive(!ui.activeSelf);

            if (ui.activeSelf)
            {
                Time.timeScale = 0f;
            }

            else
            {
                Time.timeScale = 1f;
            }
        }

        /// <summary>
        /// reload the scene
        /// </summary>
        public void Retry()
        {

            SceneManager.LoadScene("Prototype 1");

        }

        /// <summary>
        /// change scene to menu scene
        /// </summary>
        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");

        }

    }
}