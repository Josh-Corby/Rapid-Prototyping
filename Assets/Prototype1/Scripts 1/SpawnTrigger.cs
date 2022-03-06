using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{

    public class SpawnTrigger : GameBehaviour
    {
        /// <summary>
        /// References and variables
        /// </summary>
        public GameObject spawner;
        public int enemiesToSpawn;


        /// <summary>
        /// when the player collides with the trigger, the spawner triggered and amounts of enemies that
        /// should be spawned is sent to the spawn manager
        /// the respective trigger zone is then destroyed
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {

            _SM.SpawnEnemyWave(spawner, enemiesToSpawn);
            Destroy(this);
        }
    }
}