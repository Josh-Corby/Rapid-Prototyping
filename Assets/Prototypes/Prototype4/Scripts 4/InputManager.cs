using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Proto4
{
    public class InputManager : GameBehaviour<InputManager>
    {
        public string input;
        public AudioSource audio;
        public void ReadStringInput(string s)
        {
            input = s;
            audio.Play();
        }

    }
}