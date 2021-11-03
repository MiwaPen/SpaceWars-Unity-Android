using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPointsList;
    [SerializeField] private List<EnemyController> _enemyList;
    [SerializeField] private float _spawnDuration = 0f;
    [SerializeField] private float _spawnRate = 0f;
    private bool _canSpawn = false;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy",_spawnDuration, _spawnRate); 
    }
    private void SpawnEnemy()
    {
        if (_canSpawn == true)
        {
            int spawnPointIndex = GetRandomIndex(_spawnPointsList.Count);
            int enemyIndex = GetRandomIndex(_enemyList.Count);
            EnemyController enemy = Instantiate(_enemyList[enemyIndex], _spawnPointsList[spawnPointIndex].position, _spawnPointsList[spawnPointIndex].rotation);
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
        _canSpawn = true;
    }

    public void StopEnemySpawn()
    {
        _canSpawn = false;
    }
}
