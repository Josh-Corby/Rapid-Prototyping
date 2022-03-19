using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{

    //game states used
    public enum GameState
    {
        Playing,
        Paused,
    }

    // states used to manage spawner and shop
    public enum WaveState
    {
        ReadyToSpawn,
        Spawned,
        Shop
    }

        public class GameManager : GameBehaviour<GameManager>
        {

            public GameState gameState;
            public WaveState waveState;

            //values used in wave spawner function
            public float waveTimer = 3f;
            public int enemyAmount = 8;
            public int waveCount = 0;
            public int totalEnemies;

            void Start()
            {
                
                Time.timeScale = 1f;
                //gamestates are set
                gameState = GameState.Playing;
                waveState = WaveState.ReadyToSpawn;

                //UI is updated
                _UI2.UpdateWaveCount(waveCount);

            }
            void Update()
            {
                //ui updated
                _UI2.UpdateTimer(waveTimer);


                //checks if the game is in the correct state to spawn enemies
                if (waveState == WaveState.ReadyToSpawn)
                {
                    if (_SM2.enemies.Count == 0)
                    {
                        //timer countdown
                        waveTimer -= Time.deltaTime;
                        if (waveTimer <= 0)
                        {
                            //timer is reset
                            waveTimer = 3;
                            //wavecount is incremented and ui updated
                            IncrementWaveCount();
                            _UI2.UpdateWaveCount(waveCount);
                            //enemies are spawned and gamestate is changed
                            StartCoroutine(_SM2.SpawnWithDelay());
                            waveState = WaveState.Spawned;
                        }
                        else if (waveTimer == 0 && _SM2.enemies.Count == 0)
                            waveTimer = 3f;
                    }
                }
                else if (waveState == WaveState.Spawned && _SM2.enemies.Count == 0)
            {
                waveState = WaveState.ReadyToSpawn;
            }

            }

            /*
             function used to increment the wave counter, and increase the amount of enemies that get spawned in the
             next wave */
            public void IncrementWaveCount()
            {
                waveCount += 1;
                totalEnemies = (enemyAmount + (waveCount * 2));
            }


        }
    
}
