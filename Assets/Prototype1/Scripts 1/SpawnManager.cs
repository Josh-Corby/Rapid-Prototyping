using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class SpawnManager : GameBehaviour
    {
        public GameObject powerupPrefab;
        public GameObject enemyPrefab;
        public GameObject enemyPrefab2;
        private float spawnRange = 15;
        public int enemyCount;
        public int waveNumber = 1;

        private void Start()
        {
            SpawnEnemyWave(waveNumber);
        }

        void SpawnEnemyWave(int enemiesToSpawn)
        {
            if (waveNumber >= 5)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
            if (waveNumber >= 10)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
            if (waveNumber >= 15)
            {
                Instantiate(enemyPrefab2, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

            }
        }
        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
            return randomPos;
        }

        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            }
        }
    }
}