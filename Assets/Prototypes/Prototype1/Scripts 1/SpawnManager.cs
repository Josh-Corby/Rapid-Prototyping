using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class SpawnManager : GameBehaviour<SpawnManager>
    {
        /// <summary>
        /// References
        /// </summary>
        public GameObject powerupPrefab;
        public GameObject enemyPrefab;
        public GameObject enemyPrefab2;
        public GameObject blockPrefab;
        public GameObject spawner1;

        /// <summary>
        /// Variables
        /// </summary>
        private float spawnRange = 15;
        public int enemyCount;
        public static int EnemiesAlive = 0;

       
        private void Start()
        {
            //SpawnEnemyWave(waveNumber);
        }

        /// <summary>
        /// spawns a given amount enemies at randomly generated positions as well as 2 powerups at random positions.
        /// depending on how large the wave number is, different types of enemies will spawn at different amounts.
        /// </summary>
        /// <param name="_spawner"></param>
        /// <param name="enemiesToSpawn"></param>
        public void SpawnEnemyWave(GameObject _spawner, int enemiesToSpawn)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(_spawner), powerupPrefab.transform.rotation);
            Instantiate(powerupPrefab, GenerateSpawnPosition(_spawner), powerupPrefab.transform.rotation);

            if (enemiesToSpawn >= 5)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(_spawner), enemyPrefab.transform.rotation);
            }
            if (enemiesToSpawn >= 10)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(_spawner), enemyPrefab.transform.rotation);
            }
            if (enemiesToSpawn >= 15)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(_spawner), enemyPrefab.transform.rotation);
            }

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(_spawner), enemyPrefab.transform.rotation);
                

            }
        }
        /// <summary>
        /// Generates a random spawn position for an enemy to spawn in a relative position to the spawner
        /// </summary>
        /// <param name="_spawner"></param>
        /// <returns> The position the enemy will spawn at is returned </returns>
        private Vector3 GenerateSpawnPosition(GameObject _spawner)
        {
            float spawnPosX = Random.Range(_spawner.transform.position.x - spawnRange, _spawner.transform.position.x + spawnRange);
            float spawnPosZ = Random.Range(_spawner.transform.position.z - spawnRange, _spawner.transform.position.z + spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
            return randomPos;
        }
 



        //private void Update()
        //{
        //    enemyCount = FindObjectsOfType<Enemy>().Length;
        //    if (enemyCount == 0)
        //    {
        //        waveNumber++;
        //        //SpawnEnemyWave(waveNumber);

        //    }
        //}

    }
}