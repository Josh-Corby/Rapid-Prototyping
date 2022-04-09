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


        void Start()
        {
            timer = 60f;
            Time.timeScale = 0f;  
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (_P4.health <= 0)
            {
                Time.timeScale = 0f;
                _UI4.GameOver();
            }
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
            Time.timeScale = 1f;
            _UI4.StartGame();
            StartCoroutine(SpawnWithDelay());
        }
        public IEnumerator SpawnWithDelay()
        {
            while(timer >0)
            {
                //Get a random enemy to spawn
                int rndAlgoritm = Random.Range(0, algorithms.Length);
                //Get a random spawn point to spawn at
                int rndSpawn = Random.Range(0, spawnPoints.Length);
                //Instantiate a random enemy at a random spawn point
                GameObject enemy = Instantiate(algorithms[rndAlgoritm], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
                enemy.transform.SetParent(spawnPoints[rndSpawn], true);
                yield return new WaitForSeconds(spawnDelay);
            }
            
            //StartCoroutine(SpawnWithDelay());
        }
    }
}