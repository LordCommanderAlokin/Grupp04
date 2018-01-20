using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaves : MonoBehaviour
{
    void OnEnable()
    {
        EnemiesAlive = 0;
        
        instance = this;
    }
    public static EnemyWaves instance;


    public static int EnemiesAlive = 0;
    public   List<GameObject> allEnemies = new List<GameObject>();

    public Wave[] waves;

    public Transform spawnPoint;

    public GameManager gameManager;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;

    private int waveIndex = 0;


    void Update()
    {
        if (allEnemies.Count > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning wave");
        EnemiesAlive = 0;
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            gameManager.WinGame();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        allEnemies.Add(newEnemy);
        EnemiesAlive++;
    }
}
