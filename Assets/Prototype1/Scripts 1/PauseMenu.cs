using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proto1
{

    public class PauseMenu : GameBehaviour
    {
        public GameObject ui;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }
        }

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

        public void Retry()
        {

            SceneManager.LoadScene("Prototype 1");

        }

        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");

        }

    }
}