using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPointsList;
    [SerializeField] private List<EnemyController> enemyList;
    [SerializeField] private float spawnDuration = 0f;
    [SerializeField] private float spawnRate = 0f;
    private bool canSpawn = false;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy",spawnDuration,spawnRate); 
    }

    private void SpawnEnemy()
    {
        if (canSpawn==true)
        {
            int spawnPointIndex = GetRandomIndex(spawnPointsList.Count);
            int enemyIndex = GetRandomIndex(enemyList.Count);
            EnemyController enemy = Instantiate(enemyList[enemyIndex], spawnPointsList[spawnPointIndex].position, spawnPointsList[spawnPointIndex].rotation);
        }
    }

    private int GetRandomIndex(int count)
    {
        System.Random random = new System.Random();
        int index = random.Next(0, count);
        return index;
    }

    public void StartEnemySpawn()
    {
        canSpawn = true;
    }

    public void StopEnemySpawn()
    {
        canSpawn = false;
    }
}
