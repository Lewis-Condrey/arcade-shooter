using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public wave[] waves;
    public EnemyController enemy;
    public EnemyHealthManager enemyHealth;
    public float waveDelay = 5f;
    public SerializeField enemyCount;

    wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
   
    float nextSpawnTime;

   public int killed;
   private int spawned;

    private void Start()
    {
       
        
        NextWave();
        killed = 0;
        spawned = currentWave.enemyCount;
        

    }
    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            //EnemyController spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as EnemyController;
             EnemyController spawnedEnemy = Instantiate(enemy, transform.position, transform.rotation) as EnemyController;
        }        
        
        if (killed == spawned)
        {
            killed = 0;
            Invoke("NextWave", waveDelay);
        }
    }

    void OnEnemyDeath()
    {
        
        {
            NextWave();
        }
        
        print("ondeath");
    }

    void NextWave()
    {

        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            spawned = currentWave.enemyCount;
        }

        if(currentWaveNumber == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    [System.Serializable]
    public class wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;

    }

}

