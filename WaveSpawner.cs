using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public GameObject enemy;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10.0f;
    private float countdown = 10.0f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

	
	// Update is called once per frame
	void Update () {
		
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0.0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

    private IEnumerator SpawnWave ()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i=0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1.0f / wave.rate);
        }

        waveIndex++;

        

    }

    private void SpawnEnemy (GameObject enemy)
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
