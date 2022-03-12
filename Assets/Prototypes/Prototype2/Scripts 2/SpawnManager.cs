using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class SpawnManager : GameBehaviour<SpawnManager>
    {
        public GameObject enemyPrefab;
        public Transform[] spawners;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SpawnEnemy();
        }

        void SpawnEnemy()
        {
            int rndSpawn = Random.Range(0, spawners.Length);

            GameObject enemy = Instantiate(enemyPrefab, spawners[rndSpawn].position, spawners[rndSpawn].rotation);
        }
    }
}