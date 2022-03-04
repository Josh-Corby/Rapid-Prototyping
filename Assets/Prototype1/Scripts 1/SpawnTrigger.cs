using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{

    public class SpawnTrigger : GameBehaviour
    {
        public GameObject spawner;
        public int enemiesToSpawn;


        private void OnTriggerEnter(Collider other)
        {

            _SM.SpawnEnemyWave(spawner, enemiesToSpawn);
            Destroy(this);
        }
    }
}