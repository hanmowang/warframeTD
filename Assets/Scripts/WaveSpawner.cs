using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public TMP_Text waveCountdownText;

    private int waveIndex = 0;
    public GameManager gameManager;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text =  string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i <= wave.count; i++) 
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate); 
        }

        waveIndex++;
        PlayerStats.Rounds++;

        if (waveIndex == waves.Length)
        {
            
            gameManager.winLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
