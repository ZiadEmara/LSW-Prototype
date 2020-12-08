using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the spawning of enemies and the flow of waves
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Tooltip("Time between each wave (After all enemies spawn).")]
    [SerializeField] int waveInterval = 30;
    [Tooltip("Time between each spawn (enemies spawn in random bursts).")]
    [SerializeField] int spawnInterval = 10;
    [Tooltip("Maximum number of enemies that will be spawned each wave.")]
    [SerializeField] int maxSpawnPerWave = 20;
    [Tooltip("Maximum number of enemies that will be spawned at the same time.")]
    [SerializeField] int maxSpawnPerBurst = 4;
    // The character of the main player.
    [SerializeField] ACharacter player = null;
    // List of enemy prefabs that are randomly spawned from
    [SerializeField] List<GameObject> enemyPrefabs = null;
    [SerializeField] List<Transform> spawnPoints = null;
    [SerializeField] Text timerText = null;

    int currentWave = 1;
    // Remaining number of enemies to spawn.
    int numberOfEnemies = 0;
    float timer = 0f;

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer % 60).ToString();
        }
    }

    IEnumerator StartWave()
    {
        // Determine the number of enemies to spawn this wave
        numberOfEnemies = Mathf.Clamp(3 * currentWave + 1, 2, maxSpawnPerWave);

        while (numberOfEnemies > 0)
        {
            // Pick a random burst
            int burst = Random.Range(1, Mathf.Min(numberOfEnemies, maxSpawnPerBurst));
            // Subtract from the remaining enemies
            numberOfEnemies -= burst;
            // Spawn them
            SpawnEnemies(burst);
            // Wait for the next burst if there are enemies remaining
            if (numberOfEnemies > 0)
            {
                SetTimer(spawnInterval);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        // Wait for the next wave
        currentWave++;
        SetTimer(waveInterval);
        yield return new WaitForSeconds(waveInterval);
        // Start the new wave
        StartCoroutine(StartWave());
    }

    // Spawns the specified number of enemies, in random spots.
    void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Spawn();
        }
    }

    // Spawns a single enemy 
    void Spawn()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Count);
        int randLocation = Random.Range(0, spawnPoints.Count);
        Enemy enemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randLocation].position, Quaternion.identity).GetComponent<Enemy>();
        enemy.SetTarget(player.transform);
    }

    void SetTimer(int seconds)
    {
        timerText.text = seconds.ToString();
        timer = seconds;
    }
}
