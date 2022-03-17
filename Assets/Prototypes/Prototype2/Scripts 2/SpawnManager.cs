using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class SpawnManager : GameBehaviour<SpawnManager>
    {
        public GameObject enemyPrefab;
        public Transform[] spawners;

        public List<GameObject> enemies;

        public float spawnDelay = 1f;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SpawnEnemy();
        }


        public IEnumerator SpawnWithDelay()
        {
            for (int i = 0; i < _GM2.totalEnemies; i++)
            {
                //Get a random enemy to spawn
                //Get a random spawn point to spawn at
                int rndSpawn = Random.Range(0, spawners.Length);
                //Instantiate a random enemy at a random spawn point
                GameObject enemy = Instantiate(enemyPrefab, spawners[rndSpawn].position, spawners[rndSpawn].rotation);
                //Add the enemy to the enemies list
                enemies.Add(enemy);
                //Wait for the spawn delay
                yield return new WaitForSeconds(spawnDelay);
                //Run the coroutine again
            }
        }
        void SpawnEnemy()
        {
            int rndSpawn = Random.Range(0, spawners.Length);

            GameObject enemy = Instantiate(enemyPrefab, spawners[rndSpawn].position, spawners[rndSpawn].rotation);
        }

        //When a target dies, destroy it, remove it from the list, and update UI for how many enemies there are
        public void DestroyEnemy(GameObject _enemy)
        {
            Destroy(_enemy);
            enemies.Remove(_enemy);
            
        }
    }
}