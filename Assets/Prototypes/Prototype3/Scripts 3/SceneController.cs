using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proto3
{
    public class SceneController : GameBehaviour
    {
        public void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        public void ChangeScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        public string GetSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ToTitleScene()
        {
            SceneManager.LoadScene("Main_Menu");
        }



        public void QuitGame()
        {
            Application.Quit();
        }
        //public GameObject[] levels;

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.L))
        //        LoadLevel(0);
        //    if (Input.GetKeyDown(KeyCode.K))
        //        LoadLevel(1);
        //}
        //public void LoadLevel(int _level)
        //{
        //    for (int i = 0; i < levels.Length; i++)
        //    {
        //        if (_level == i)
        //        {
        //            Destroy(currentLevel);
        //            currentLevel = (levels[_level]);
        //            Instantiate(currentLevel);

        //        }

        //    }
        //}
    }
}