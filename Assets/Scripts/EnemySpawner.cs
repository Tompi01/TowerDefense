using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner main;

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();


    public int currentWave = 1;
    private float timeSinceLastSpawn;
    public int enemiesAlive = 0;
    public int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private int rdn;
    //public Dictionary<GameObject, int> InPath;
    public IDictionary<GameObject, int> objetsuper = new Dictionary<GameObject, int>();

    private void Awake()
    {
        StartCoroutine(StartWave());
    }


    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(StartWave());
        main = this;
    }

    public void Leave()
    {
        currentWave = 0;
        EndWave();

    }

    private void Update()
    {
        rdn = Random.Range(0, 9999);
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0){
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive <= 0 && enemiesLeftToSpawn <= 0)
        {
            EndWave();
        }

        if(currentWave >= 5)
        {
            Leave();
            LevelManager.Live = 0;
            Time.timeScale = 0;
        }
    }

    private void enemyDestroyed()
    {
        enemiesAlive--;
    }



    public IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = enemiesPerWaves();
    }

    public void EndWave()
    {
        enemiesAlive = 0;
        enemiesLeftToSpawn = 0;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        LevelManager.Money += 75;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {

        GameObject prefabsToSpawn = enemyPrefabs[0];
        int i=0;
        prefabsToSpawn.name = rdn.ToString();
        foreach(var startpoint in LevelManager.main.path)
        {
            var e = Instantiate(prefabsToSpawn.gameObject, startpoint.Key.position, Quaternion.identity);
            objetsuper.Add(e, i);
            i++;
        }
    }

    private int enemiesPerWaves()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

}
