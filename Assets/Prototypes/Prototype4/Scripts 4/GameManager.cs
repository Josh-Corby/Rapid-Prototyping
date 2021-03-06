using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto4
{
    public class GameManager : GameBehaviour<GameManager>
    {
        public Transform[] spawnPoints;
        public GameObject[] additionAlgorithms;
        public GameObject[] subtractionAlgorithms;
        public GameObject[] algorithms;
        public float spawnDelay;
        public float timer;
        public float speed;


        void Start()
        {
            Time.timeScale = 0f;  
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (_P4.health <= 0)
            {
                Time.timeScale = 0f;
                _UI4.GameOver();
            }
                
            if(timer >=60)
            {
                Time.timeScale = 0f;
                _UI4.Victory();
            }
        }

        public void ChangeDifficulty(string _diff)
        {
            if (_diff == "easy")
                speed = 30;
            else if (_diff == "medium")
                speed = 40;
            else if (_diff == "hard")
                speed = 50;
        }
        public void GetAlgorithms(string _type)
        {
            if (_type == "addition")
            {
                algorithms = additionAlgorithms;
            }
            else if(_type == "subtraction")
            {
                algorithms = subtractionAlgorithms;
            }       
        }

        public void StartGame()
        {
            timer = 0f;
            Time.timeScale = 1f;
            _UI4.StartGame();
            StartCoroutine(SpawnWithDelay());
            StartCoroutine(IncreaseSpeed());
        }
        public IEnumerator SpawnWithDelay()
        {
            {
                //Get a random enemy to spawn
                int rndAlgoritm = Random.Range(0, algorithms.Length);
                //Get a random spawn point to spawn at
                int rndSpawn = Random.Range(0, spawnPoints.Length);
                //Instantiate a random enemy at a random spawn point
                GameObject enemy = Instantiate(algorithms[rndAlgoritm], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
                enemy.transform.SetParent(spawnPoints[rndSpawn], true);
                yield return new WaitForSeconds(spawnDelay);
                StartCoroutine(SpawnWithDelay());
            }
        }

        public IEnumerator IncreaseSpeed()
        {
            yield return new WaitForSeconds(10);
            speed *= 1.2f;
            StartCoroutine(SpawnWithDelay());
        }
    }
}